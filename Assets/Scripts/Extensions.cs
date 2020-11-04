using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static Vector3 RelativeDirection(this Camera _cam, Vector2 _direction)
    {
        if (!_cam)
        {
            return _direction;
        }

        float yaw = _cam.transform.rotation.eulerAngles.y;

        Vector3 dir = new Vector3(_direction.x, 0.0f, _direction.y);

        dir = Quaternion.Euler(new Vector3(0.0f, yaw, 0.0f)) * dir;

        return dir;
    }
}
