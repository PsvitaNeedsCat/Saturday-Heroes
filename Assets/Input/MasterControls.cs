// GENERATED AUTOMATICALLY FROM 'Assets/Input/MasterControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MasterControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MasterControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MasterControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""264ebfac-65c6-46df-9057-588d4a5153b3"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""0337b2f3-371c-4399-b35a-68ef5e13fd35"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""938e362b-6eea-48fd-a0bc-060ead04d0d7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Revive"",
                    ""type"": ""Button"",
                    ""id"": ""974c1635-890b-438c-a7ce-60e8d3297c55"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.2)""
                },
                {
                    ""name"": ""Card Selection"",
                    ""type"": ""Value"",
                    ""id"": ""269b735c-076e-453e-b484-58895ca42a02"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Play Card"",
                    ""type"": ""Button"",
                    ""id"": ""ce281ee4-c274-4cd9-ab61-9875fa19a166"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2fb15d35-5a80-4232-804d-65310a962ad6"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0bbc38c0-c37c-4d11-a6ad-03b91f76f357"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bce523ed-d2b6-4b6b-b28f-26de9a006065"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Revive"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""c3d249b9-a934-4fd2-a4cd-454386729233"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Card Selection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""06e4b0e6-c58d-4894-ad25-98d1618dbb7a"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Card Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b7ddab94-eef5-4418-bc53-08c967789810"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Card Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6724961f-f21b-4cde-bd9f-456fe8acf9b2"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Play Card"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player1 Keyboard"",
            ""id"": ""0b31af19-c21f-4503-a118-0fc6181edf75"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""59f5b112-8edc-4afc-9f11-2226f71ee650"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""be036488-7d9f-4b9c-ab59-4a6efdd40af1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Revive"",
                    ""type"": ""Button"",
                    ""id"": ""0e0faba8-4a5b-4a9a-9584-3c9f72b2d28a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.2)""
                },
                {
                    ""name"": ""Card Selection"",
                    ""type"": ""Value"",
                    ""id"": ""3684b1cb-ef7f-45b6-b80d-66c297123655"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Play Card"",
                    ""type"": ""Button"",
                    ""id"": ""6caf29de-88cf-45a9-a2ef-8baf29608591"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e6fd074f-441a-429b-988c-160586255e5f"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""284d8de3-c0cd-4a69-a109-3cb53a04c8bd"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""efc9c21c-4710-4e8a-9a57-eb3d4071dbbd"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d3ea65f3-1e4c-4d73-a75a-4c304c19e06c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""305020e1-9402-4790-80fc-a26dc2246f54"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2d5f3feb-69a4-471e-8224-6a7131a677cf"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""bbad907c-12f2-4a54-9d21-05da1ccd5fbe"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f3fcef90-9b55-42bb-a5ce-2356667ef857"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9204d1a1-2e80-429c-ae8c-d73e4822d3c5"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Revive"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c504b031-f8c0-4487-95db-af00cacf6066"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Revive"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""c933d112-c4af-47c8-bf74-64713caf8eb3"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Card Selection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6330967a-34a2-4114-b8eb-f3824aa0b181"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Card Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0a134aa1-3619-403f-a1bd-ef76ada16ca1"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Card Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""HK"",
                    ""id"": ""815d9436-83ab-43cc-a052-552c1b388567"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Card Selection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c6bf226f-12eb-4d4f-8658-78db9bb4c973"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Card Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""7ec9689e-3a82-49dd-8406-c3af0f0ba441"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Card Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""385874c8-197c-4dc2-adca-de031e52b9d5"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Play Card"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34933906-3069-48d5-adc8-e3f70e36f70e"",
                    ""path"": ""<Keyboard>/u"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Play Card"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player2 Keyboard"",
            ""id"": ""86202f63-5f4b-4b3e-8562-21da69c1af01"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""c3f60823-5e0b-4ee0-af66-94ce466c552e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""dd68e5bc-47c9-4a1b-8651-117d06cabffe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Revive"",
                    ""type"": ""Button"",
                    ""id"": ""0f1560ff-4484-4996-855b-2457dbad9271"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.2)""
                },
                {
                    ""name"": ""Card Selection"",
                    ""type"": ""Value"",
                    ""id"": ""302baf17-a459-4c3e-909e-fb3496d0f0d7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Play Card"",
                    ""type"": ""Button"",
                    ""id"": ""4b902ad7-5bd0-442f-b83e-d22e4d2c8d26"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8d36b4e2-1d3b-4592-b0fe-f6a62a5312f4"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""235b5f13-4552-4cbe-88c0-553c5d61f727"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7bfc50c2-5bf2-491d-b032-997335213112"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b3b110e4-e757-4146-bb44-c50c869c6513"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""78cd2698-6a71-4b2c-a1bc-c9430895f848"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2ff3261e-5bfc-47aa-995b-b6ffe38a59cf"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""53fae7a9-7ee1-4603-b70e-e72c5e7d7aa9"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""09a722a8-1ef9-497d-aa54-403c8d2a06e8"",
                    ""path"": ""<Keyboard>/numpad5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b7a498b-b7ca-482b-ad65-70263b2292ef"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Revive"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6a2d88c-13cf-435f-9de0-f5ad99db3e7b"",
                    ""path"": ""<Keyboard>/numpad5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Revive"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""df68a99b-d26a-4f06-9323-c24f3ed9e627"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Card Selection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""9097774d-a4fb-4715-9ec3-670f5cd97b57"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Card Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""254d00d1-da7f-4975-b3d0-735e047bfe46"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Card Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""46"",
                    ""id"": ""289c6ee4-ece0-4d8e-ab32-94a8d64928b8"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Card Selection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""464f01b1-02f3-4658-8079-405d2c8129fd"",
                    ""path"": ""<Keyboard>/numpad4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Card Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""19e21bbb-ad9c-428f-9dae-f01317eb7c12"",
                    ""path"": ""<Keyboard>/numpad6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Card Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""038b1cc6-3f44-4f85-8ac3-1ea38af18278"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Play Card"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""11c78e74-ed08-414e-a85c-65f09034e8f0"",
                    ""path"": ""<Keyboard>/numpad8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Play Card"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""3a2c4ab6-057c-4e93-8dbf-b98700c86713"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""ea960c6a-3c49-423d-8229-61700e4efce8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""8f1c15eb-8823-4da7-bcad-e750197449c6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""5fc83ced-2602-4f5f-9169-41305745cf16"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""151437fe-205a-4aff-8277-357ef4601bf4"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dc6c4df1-b206-4458-8222-3f731668f5a8"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7fa5a064-6963-4dcd-8227-f03038d54532"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c24b284e-fc46-4cea-93cc-8331bc1b6406"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Console"",
            ""id"": ""dcb3cf2f-24dd-46c2-9040-b85149821e1a"",
            ""actions"": [
                {
                    ""name"": ""Toggle Console"",
                    ""type"": ""Button"",
                    ""id"": ""770e8835-a91f-48c7-91ee-ae0d69b542cb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Handle Input"",
                    ""type"": ""Button"",
                    ""id"": ""9ea468ef-8371-4a0c-a7db-9ebc767f83ea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Switch Commands"",
                    ""type"": ""Value"",
                    ""id"": ""0e138902-a475-4f02-82a5-b8237c6c1062"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ec4c73a3-0839-4b33-be93-fceadbc26c23"",
                    ""path"": ""<Keyboard>/backquote"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Toggle Console"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""261367fa-448e-474f-971b-52f2e9c769b0"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Handle Input"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e296f0f-cd43-4c81-92a9-c4e52a55d209"",
                    ""path"": ""<Keyboard>/numpadEnter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Handle Input"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""3268b49e-ad46-4dc2-b96e-23186c80dec3"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch Commands"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c2371112-ef21-4f54-aaae-57948c5ec1b3"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Switch Commands"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""aa247ac2-05e8-4e9a-b1fa-26ad700702b0"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Switch Commands"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Attack = m_Player.FindAction("Attack", throwIfNotFound: true);
        m_Player_Revive = m_Player.FindAction("Revive", throwIfNotFound: true);
        m_Player_CardSelection = m_Player.FindAction("Card Selection", throwIfNotFound: true);
        m_Player_PlayCard = m_Player.FindAction("Play Card", throwIfNotFound: true);
        // Player1 Keyboard
        m_Player1Keyboard = asset.FindActionMap("Player1 Keyboard", throwIfNotFound: true);
        m_Player1Keyboard_Movement = m_Player1Keyboard.FindAction("Movement", throwIfNotFound: true);
        m_Player1Keyboard_Attack = m_Player1Keyboard.FindAction("Attack", throwIfNotFound: true);
        m_Player1Keyboard_Revive = m_Player1Keyboard.FindAction("Revive", throwIfNotFound: true);
        m_Player1Keyboard_CardSelection = m_Player1Keyboard.FindAction("Card Selection", throwIfNotFound: true);
        m_Player1Keyboard_PlayCard = m_Player1Keyboard.FindAction("Play Card", throwIfNotFound: true);
        // Player2 Keyboard
        m_Player2Keyboard = asset.FindActionMap("Player2 Keyboard", throwIfNotFound: true);
        m_Player2Keyboard_Movement = m_Player2Keyboard.FindAction("Movement", throwIfNotFound: true);
        m_Player2Keyboard_Attack = m_Player2Keyboard.FindAction("Attack", throwIfNotFound: true);
        m_Player2Keyboard_Revive = m_Player2Keyboard.FindAction("Revive", throwIfNotFound: true);
        m_Player2Keyboard_CardSelection = m_Player2Keyboard.FindAction("Card Selection", throwIfNotFound: true);
        m_Player2Keyboard_PlayCard = m_Player2Keyboard.FindAction("Play Card", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_Movement = m_Menu.FindAction("Movement", throwIfNotFound: true);
        m_Menu_Submit = m_Menu.FindAction("Submit", throwIfNotFound: true);
        m_Menu_Cancel = m_Menu.FindAction("Cancel", throwIfNotFound: true);
        // Console
        m_Console = asset.FindActionMap("Console", throwIfNotFound: true);
        m_Console_ToggleConsole = m_Console.FindAction("Toggle Console", throwIfNotFound: true);
        m_Console_HandleInput = m_Console.FindAction("Handle Input", throwIfNotFound: true);
        m_Console_SwitchCommands = m_Console.FindAction("Switch Commands", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Attack;
    private readonly InputAction m_Player_Revive;
    private readonly InputAction m_Player_CardSelection;
    private readonly InputAction m_Player_PlayCard;
    public struct PlayerActions
    {
        private @MasterControls m_Wrapper;
        public PlayerActions(@MasterControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Attack => m_Wrapper.m_Player_Attack;
        public InputAction @Revive => m_Wrapper.m_Player_Revive;
        public InputAction @CardSelection => m_Wrapper.m_Player_CardSelection;
        public InputAction @PlayCard => m_Wrapper.m_Player_PlayCard;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Attack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Revive.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRevive;
                @Revive.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRevive;
                @Revive.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRevive;
                @CardSelection.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCardSelection;
                @CardSelection.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCardSelection;
                @CardSelection.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCardSelection;
                @PlayCard.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlayCard;
                @PlayCard.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlayCard;
                @PlayCard.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlayCard;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Revive.started += instance.OnRevive;
                @Revive.performed += instance.OnRevive;
                @Revive.canceled += instance.OnRevive;
                @CardSelection.started += instance.OnCardSelection;
                @CardSelection.performed += instance.OnCardSelection;
                @CardSelection.canceled += instance.OnCardSelection;
                @PlayCard.started += instance.OnPlayCard;
                @PlayCard.performed += instance.OnPlayCard;
                @PlayCard.canceled += instance.OnPlayCard;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Player1 Keyboard
    private readonly InputActionMap m_Player1Keyboard;
    private IPlayer1KeyboardActions m_Player1KeyboardActionsCallbackInterface;
    private readonly InputAction m_Player1Keyboard_Movement;
    private readonly InputAction m_Player1Keyboard_Attack;
    private readonly InputAction m_Player1Keyboard_Revive;
    private readonly InputAction m_Player1Keyboard_CardSelection;
    private readonly InputAction m_Player1Keyboard_PlayCard;
    public struct Player1KeyboardActions
    {
        private @MasterControls m_Wrapper;
        public Player1KeyboardActions(@MasterControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player1Keyboard_Movement;
        public InputAction @Attack => m_Wrapper.m_Player1Keyboard_Attack;
        public InputAction @Revive => m_Wrapper.m_Player1Keyboard_Revive;
        public InputAction @CardSelection => m_Wrapper.m_Player1Keyboard_CardSelection;
        public InputAction @PlayCard => m_Wrapper.m_Player1Keyboard_PlayCard;
        public InputActionMap Get() { return m_Wrapper.m_Player1Keyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player1KeyboardActions set) { return set.Get(); }
        public void SetCallbacks(IPlayer1KeyboardActions instance)
        {
            if (m_Wrapper.m_Player1KeyboardActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_Player1KeyboardActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_Player1KeyboardActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_Player1KeyboardActionsCallbackInterface.OnMovement;
                @Attack.started -= m_Wrapper.m_Player1KeyboardActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_Player1KeyboardActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_Player1KeyboardActionsCallbackInterface.OnAttack;
                @Revive.started -= m_Wrapper.m_Player1KeyboardActionsCallbackInterface.OnRevive;
                @Revive.performed -= m_Wrapper.m_Player1KeyboardActionsCallbackInterface.OnRevive;
                @Revive.canceled -= m_Wrapper.m_Player1KeyboardActionsCallbackInterface.OnRevive;
                @CardSelection.started -= m_Wrapper.m_Player1KeyboardActionsCallbackInterface.OnCardSelection;
                @CardSelection.performed -= m_Wrapper.m_Player1KeyboardActionsCallbackInterface.OnCardSelection;
                @CardSelection.canceled -= m_Wrapper.m_Player1KeyboardActionsCallbackInterface.OnCardSelection;
                @PlayCard.started -= m_Wrapper.m_Player1KeyboardActionsCallbackInterface.OnPlayCard;
                @PlayCard.performed -= m_Wrapper.m_Player1KeyboardActionsCallbackInterface.OnPlayCard;
                @PlayCard.canceled -= m_Wrapper.m_Player1KeyboardActionsCallbackInterface.OnPlayCard;
            }
            m_Wrapper.m_Player1KeyboardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Revive.started += instance.OnRevive;
                @Revive.performed += instance.OnRevive;
                @Revive.canceled += instance.OnRevive;
                @CardSelection.started += instance.OnCardSelection;
                @CardSelection.performed += instance.OnCardSelection;
                @CardSelection.canceled += instance.OnCardSelection;
                @PlayCard.started += instance.OnPlayCard;
                @PlayCard.performed += instance.OnPlayCard;
                @PlayCard.canceled += instance.OnPlayCard;
            }
        }
    }
    public Player1KeyboardActions @Player1Keyboard => new Player1KeyboardActions(this);

    // Player2 Keyboard
    private readonly InputActionMap m_Player2Keyboard;
    private IPlayer2KeyboardActions m_Player2KeyboardActionsCallbackInterface;
    private readonly InputAction m_Player2Keyboard_Movement;
    private readonly InputAction m_Player2Keyboard_Attack;
    private readonly InputAction m_Player2Keyboard_Revive;
    private readonly InputAction m_Player2Keyboard_CardSelection;
    private readonly InputAction m_Player2Keyboard_PlayCard;
    public struct Player2KeyboardActions
    {
        private @MasterControls m_Wrapper;
        public Player2KeyboardActions(@MasterControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player2Keyboard_Movement;
        public InputAction @Attack => m_Wrapper.m_Player2Keyboard_Attack;
        public InputAction @Revive => m_Wrapper.m_Player2Keyboard_Revive;
        public InputAction @CardSelection => m_Wrapper.m_Player2Keyboard_CardSelection;
        public InputAction @PlayCard => m_Wrapper.m_Player2Keyboard_PlayCard;
        public InputActionMap Get() { return m_Wrapper.m_Player2Keyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player2KeyboardActions set) { return set.Get(); }
        public void SetCallbacks(IPlayer2KeyboardActions instance)
        {
            if (m_Wrapper.m_Player2KeyboardActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_Player2KeyboardActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_Player2KeyboardActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_Player2KeyboardActionsCallbackInterface.OnMovement;
                @Attack.started -= m_Wrapper.m_Player2KeyboardActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_Player2KeyboardActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_Player2KeyboardActionsCallbackInterface.OnAttack;
                @Revive.started -= m_Wrapper.m_Player2KeyboardActionsCallbackInterface.OnRevive;
                @Revive.performed -= m_Wrapper.m_Player2KeyboardActionsCallbackInterface.OnRevive;
                @Revive.canceled -= m_Wrapper.m_Player2KeyboardActionsCallbackInterface.OnRevive;
                @CardSelection.started -= m_Wrapper.m_Player2KeyboardActionsCallbackInterface.OnCardSelection;
                @CardSelection.performed -= m_Wrapper.m_Player2KeyboardActionsCallbackInterface.OnCardSelection;
                @CardSelection.canceled -= m_Wrapper.m_Player2KeyboardActionsCallbackInterface.OnCardSelection;
                @PlayCard.started -= m_Wrapper.m_Player2KeyboardActionsCallbackInterface.OnPlayCard;
                @PlayCard.performed -= m_Wrapper.m_Player2KeyboardActionsCallbackInterface.OnPlayCard;
                @PlayCard.canceled -= m_Wrapper.m_Player2KeyboardActionsCallbackInterface.OnPlayCard;
            }
            m_Wrapper.m_Player2KeyboardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Revive.started += instance.OnRevive;
                @Revive.performed += instance.OnRevive;
                @Revive.canceled += instance.OnRevive;
                @CardSelection.started += instance.OnCardSelection;
                @CardSelection.performed += instance.OnCardSelection;
                @CardSelection.canceled += instance.OnCardSelection;
                @PlayCard.started += instance.OnPlayCard;
                @PlayCard.performed += instance.OnPlayCard;
                @PlayCard.canceled += instance.OnPlayCard;
            }
        }
    }
    public Player2KeyboardActions @Player2Keyboard => new Player2KeyboardActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_Movement;
    private readonly InputAction m_Menu_Submit;
    private readonly InputAction m_Menu_Cancel;
    public struct MenuActions
    {
        private @MasterControls m_Wrapper;
        public MenuActions(@MasterControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Menu_Movement;
        public InputAction @Submit => m_Wrapper.m_Menu_Submit;
        public InputAction @Cancel => m_Wrapper.m_Menu_Cancel;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnMovement;
                @Submit.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnSubmit;
                @Cancel.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnCancel;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);

    // Console
    private readonly InputActionMap m_Console;
    private IConsoleActions m_ConsoleActionsCallbackInterface;
    private readonly InputAction m_Console_ToggleConsole;
    private readonly InputAction m_Console_HandleInput;
    private readonly InputAction m_Console_SwitchCommands;
    public struct ConsoleActions
    {
        private @MasterControls m_Wrapper;
        public ConsoleActions(@MasterControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @ToggleConsole => m_Wrapper.m_Console_ToggleConsole;
        public InputAction @HandleInput => m_Wrapper.m_Console_HandleInput;
        public InputAction @SwitchCommands => m_Wrapper.m_Console_SwitchCommands;
        public InputActionMap Get() { return m_Wrapper.m_Console; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ConsoleActions set) { return set.Get(); }
        public void SetCallbacks(IConsoleActions instance)
        {
            if (m_Wrapper.m_ConsoleActionsCallbackInterface != null)
            {
                @ToggleConsole.started -= m_Wrapper.m_ConsoleActionsCallbackInterface.OnToggleConsole;
                @ToggleConsole.performed -= m_Wrapper.m_ConsoleActionsCallbackInterface.OnToggleConsole;
                @ToggleConsole.canceled -= m_Wrapper.m_ConsoleActionsCallbackInterface.OnToggleConsole;
                @HandleInput.started -= m_Wrapper.m_ConsoleActionsCallbackInterface.OnHandleInput;
                @HandleInput.performed -= m_Wrapper.m_ConsoleActionsCallbackInterface.OnHandleInput;
                @HandleInput.canceled -= m_Wrapper.m_ConsoleActionsCallbackInterface.OnHandleInput;
                @SwitchCommands.started -= m_Wrapper.m_ConsoleActionsCallbackInterface.OnSwitchCommands;
                @SwitchCommands.performed -= m_Wrapper.m_ConsoleActionsCallbackInterface.OnSwitchCommands;
                @SwitchCommands.canceled -= m_Wrapper.m_ConsoleActionsCallbackInterface.OnSwitchCommands;
            }
            m_Wrapper.m_ConsoleActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ToggleConsole.started += instance.OnToggleConsole;
                @ToggleConsole.performed += instance.OnToggleConsole;
                @ToggleConsole.canceled += instance.OnToggleConsole;
                @HandleInput.started += instance.OnHandleInput;
                @HandleInput.performed += instance.OnHandleInput;
                @HandleInput.canceled += instance.OnHandleInput;
                @SwitchCommands.started += instance.OnSwitchCommands;
                @SwitchCommands.performed += instance.OnSwitchCommands;
                @SwitchCommands.canceled += instance.OnSwitchCommands;
            }
        }
    }
    public ConsoleActions @Console => new ConsoleActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnRevive(InputAction.CallbackContext context);
        void OnCardSelection(InputAction.CallbackContext context);
        void OnPlayCard(InputAction.CallbackContext context);
    }
    public interface IPlayer1KeyboardActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnRevive(InputAction.CallbackContext context);
        void OnCardSelection(InputAction.CallbackContext context);
        void OnPlayCard(InputAction.CallbackContext context);
    }
    public interface IPlayer2KeyboardActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnRevive(InputAction.CallbackContext context);
        void OnCardSelection(InputAction.CallbackContext context);
        void OnPlayCard(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
    }
    public interface IConsoleActions
    {
        void OnToggleConsole(InputAction.CallbackContext context);
        void OnHandleInput(InputAction.CallbackContext context);
        void OnSwitchCommands(InputAction.CallbackContext context);
    }
}
