using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatConsole : MonoBehaviour
{
    // Variables go here

    // Console variables
    private bool m_showConsole = false;
    private bool m_showHelp = false;
    private bool m_showTimeScale = false;
    private bool m_showFPS = false;
    private float m_deltaTime = 0.0f;
    private GUIStyle m_textStyle;
    private Vector2 m_scroll;
    private string m_input = "";
    private bool m_justOpened = false;
    private List<string> m_previousEntries = new List<string>();
    private int m_entryIndex = 0;
    private bool m_justRetrievedEntry = false;

    // Commands
    public static CheatCommand HELP;
    public static CheatCommand<float> TIME_SCALE;
    public static CheatCommand SHOW_TIME_SCALE;
    public static CheatCommand SHOW_FPS;
    public static CheatCommand VSYNC;
    public static CheatCommand KILL_BOSS;
    public static CheatCommand<int> KILL_PLAYER;

    public List<object> m_commandList;

    private void Awake()
    {
        m_textStyle = new GUIStyle();
        m_textStyle.fontSize = 18;
        m_textStyle.normal.textColor = Color.white;

        // Commands
        HELP = new CheatCommand("help", "Displays the list of commands", "help", () =>
        {
            m_showHelp = !m_showHelp;

            if (m_showHelp)
            {
                OnToggleDebug();
            }
        });

        TIME_SCALE = new CheatCommand<float>("time_scale", "Changes time scale", "time_scale <float>", (x) =>
        {
            Time.timeScale = x;
        });

        SHOW_TIME_SCALE = new CheatCommand("show_time_scale", "Toggles showing time scale", "show_time_scale", () =>
        {
            m_showTimeScale = !m_showTimeScale;
        });

        SHOW_FPS = new CheatCommand("show_fps", "Toggles showing FPS", "show_fps", () =>
        {
            m_showFPS = !m_showFPS;
        });

        VSYNC = new CheatCommand("vsync", "Toggles vsync", "vsync", () =>
        {
            if (QualitySettings.vSyncCount == 0)
            {
                QualitySettings.vSyncCount = 1;
            }
            else
            {
                QualitySettings.vSyncCount = 0;
            }
        });

        KILL_BOSS = new CheatCommand("kill_boss", "Instantly kills the boss", "kill_boss", () =>
        {
            FindObjectOfType<BasicBoss>().m_healthComp.ForceKill();
        });

        KILL_PLAYER = new CheatCommand<int>("kill_player", "Instantly kills the player specified", "kill_player <player number>", (x) =>
        {
            if (x < 0 || x > 1)
            {
                return;
            }

            Player[] players = FindObjectsOfType<Player>();
            foreach (Player p in players)
            {
                if (p.m_playerNumber == x)
                {
                    p.GetComponent<HealthComponent>().ForceKill();
                }
            }
        });

        // Commands list
        m_commandList = new List<object>()
        {
            HELP,
            TIME_SCALE,
            SHOW_TIME_SCALE,
            SHOW_FPS,
            VSYNC,
            KILL_BOSS,
            KILL_PLAYER,
        };
    }

    // Invokes the correct command based on what's in the console
    private void HandleInput()
    {
        if (m_previousEntries.Count <= 0 || m_previousEntries[m_previousEntries.Count - 1] != m_input)
        {
            m_previousEntries.Add(m_input);
        }
        string[] properties = m_input.Split(' ');

        for (int i = 0; i < m_commandList.Count; i++)
        {
            CheatCommandBase commandBase = m_commandList[i] as CheatCommandBase;

            if (properties[0] == commandBase.m_commandId)
            {
                CheatCommand command = (m_commandList[i] as CheatCommand);
                CheatCommand<int> intCommand = (m_commandList[i] as CheatCommand<int>);
                CheatCommand<float> floatCommand = (m_commandList[i] as CheatCommand<float>);
                CheatCommand<string> stringCommand = (m_commandList[i] as CheatCommand<string>);
                CheatCommand<Vector3> vectorThreeCommand = (m_commandList[i] as CheatCommand<Vector3>);

                if (command != null)
                {
                    command.Invoke();
                }
                else if (intCommand != null)
                {
                    int parameter;
                    if (int.TryParse(properties[1], out parameter))
                    {
                        intCommand.Invoke(parameter);
                    }
                }
                else if (floatCommand != null)
                {
                    float parameter;
                    if (float.TryParse(properties[1], out parameter))
                    {
                        floatCommand.Invoke(parameter);
                    }
                }
                else if (stringCommand != null)
                {
                    stringCommand.Invoke(properties[1]);
                }
                else if (vectorThreeCommand != null)
                {
                    Vector3 vec;

                    if (float.TryParse(properties[1], out vec.x) && float.TryParse(properties[2], out vec.y) && float.TryParse(properties[3], out vec.z))
                    {
                        vectorThreeCommand.Invoke(vec);
                    }
                }
            }
        }
    }

    // Displays the console
    private void OnGUI()
    {
        if (m_showTimeScale)
        {
            GUI.Label(new Rect(Screen.width - 350, 0, 200, 50), "Time scale: " + Time.timeScale.ToString(), m_textStyle);
        }

        if (m_showFPS)
        {
            float miliSeconds = m_deltaTime * 1000.0f;
            float fps = 1.0f / m_deltaTime;
            string fpsText = string.Format("{0:0.0} ms ({1:0.} fps)", miliSeconds, fps);
            GUI.Label(new Rect(Screen.width - 150, 0, 200, 50), fpsText, m_textStyle);
        }

        if (!m_showConsole)
        {
            return;
        }

        float consoleHeight = 0.0f;

        if (m_showHelp)
        {
            GUI.Box(new Rect(0, consoleHeight, Screen.width, 100), "");

            Rect viewport = new Rect(0, 0, Screen.width - 30, 20 * m_commandList.Count);

            m_scroll = GUI.BeginScrollView(new Rect(0, consoleHeight + 5.0f, Screen.width, 90), m_scroll, viewport);

            for (int i = 0; i < m_commandList.Count; i++)
            {
                CheatCommandBase command = m_commandList[i] as CheatCommandBase;
                string label = $"{command.m_commandFormat} - {command.m_commandDescription}";
                Rect labelRect = new Rect(5, 20 * i, viewport.width - 100, 20);

                GUI.Label(labelRect, label);
            }

            GUI.EndScrollView();
            consoleHeight += 100.0f;
        }

        GUI.Box(new Rect(0, consoleHeight, Screen.width, 30), "");
        GUI.backgroundColor = new Color(0, 0, 0, 0);

        GUI.SetNextControlName("ConsoleInput");
        m_input = GUI.TextField(new Rect(10.0f, consoleHeight + 5.0f, Screen.width - 20.0f, 20.0f), m_input);

        // User has just pressed Up or Down on the keyboard
        if (m_justRetrievedEntry)
        {
            TextEditor textEditor = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);
            textEditor.MoveLineEnd();
            m_justRetrievedEntry = false;
        }

        // On opened
        if (m_justOpened)
        {
            m_justOpened = false;

            GUI.FocusControl("ConsoleInput");
        }
    }

    private void Update()
    {
        m_deltaTime += (Time.unscaledDeltaTime - m_deltaTime) * 0.1f;
    }

    public bool ConsoleOpen()
    {
        return m_showConsole;
    }

    public void OnReturn()
    {
        if (m_showConsole)
        {
            HandleInput();
            m_input = "";
            OnToggleDebug();
        }
    }

    // Toggles the debug console
    public void OnToggleDebug()
    {
        m_entryIndex = m_previousEntries.Count;

        m_showConsole = !m_showConsole;

        if (m_showConsole)
        {
            m_justOpened = true;
            m_input = "";
        }
    }

    // Retrieves the previous entry and places it in the debug console
    public void PreviousEntry()
    {
        if (!ConsoleOpen() || m_entryIndex - 1 < 0)
        {
            return;
        }

        --m_entryIndex;
        m_input = m_previousEntries[m_entryIndex];

        m_justRetrievedEntry = true;
    }

    // Retrieves the next entry and places it in the debug console
    public void NextEntry()
    {
        if (!ConsoleOpen() || m_entryIndex + 1 >= m_previousEntries.Count)
        {
            return;
        }

        ++m_entryIndex;
        m_input = m_previousEntries[m_entryIndex];

        m_justRetrievedEntry = true;
    }
}
