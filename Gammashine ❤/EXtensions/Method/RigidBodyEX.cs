using Snaplight;

using UnityEngine;

public static class RigidBodyEX
{
    private const float KmhInMph = 1.609F;
    private const float KmhInMs = 3.6F;

    private static Vector3 lastKnownSurfaceNormal = Vector3.up;

    private static float _limitationHorizontal;
    private static float _limitationVertical;

    public static void Limitation(this Rigidbody rb, float limitHorizontalVelocity, float limitVerticalVelocity)
    {
        _limitationHorizontal = limitHorizontalVelocity;
        _limitationVertical = limitVerticalVelocity;
    }

    public static void Acceleration(this Rigidbody rb, Vector3 movement)
    {
        Vector3 V3 = rb.transform.TransformDirection(movement);

        rb.velocity += V3 * Time.fixedDeltaTime;

        VelocityHorizontalLimit(rb, _limitationHorizontal);
    }

    public static void Acceleration(this Rigidbody rb, Vector3 movement, float limitHorizontalVelocity)
    {
        Vector3 V3 = rb.transform.TransformDirection(movement);

        rb.velocity += V3 * Time.fixedDeltaTime;

        VelocityHorizontalLimit(rb, limitHorizontalVelocity);
    }

    public static void Deceleration(this Rigidbody rb, float deceleration)
    {
        _limitationHorizontal = Mathf.Lerp(_limitationHorizontal, 0, deceleration * Time.deltaTime);

        VelocityHorizontalLimit(rb, _limitationHorizontal);
    }

    public static Vector3 MovementSurfaceAngle(this Rigidbody rb, Vector3 movement, Vector3 directionRaytouch, Vector3 surfaceRaytouch)
    {
        if (Physics.Raycast(rb.position, directionRaytouch, out RaycastHit checkoutRaytouch))
        {
            lastKnownSurfaceNormal = rb.transform.InverseTransformDirection(checkoutRaytouch.normal);
        }

        Quaternion forceRotation = Quaternion.FromToRotation(surfaceRaytouch, lastKnownSurfaceNormal);

        return forceRotation * movement;
    }

    public static Vector3 MovementSurfaceAngleRaw(this Rigidbody rb, Vector3 movement, Vector3 directionRaytouch, Vector3 surfaceRaytouch)
    {
        if (Physics.Raycast(rb.position, directionRaytouch, out RaycastHit checkoutRaytouch))
        {
            Vector3 checkoutSurfaceRaytouch = rb.transform.InverseTransformDirection(checkoutRaytouch.normal);

            Quaternion forceRotation = Quaternion.FromToRotation(surfaceRaytouch, checkoutSurfaceRaytouch);

            return _ = forceRotation * movement;
        }

        return movement;
    }

    public static void VelocityLimit(this Rigidbody rb, float limitHorizontal, float limitVertical)
    {
        float sqrMagnitudeHorizontal = (rb.velocity.x * rb.velocity.x) + (rb.velocity.z * rb.velocity.z);

        if (sqrMagnitudeHorizontal > limitHorizontal * limitHorizontal)
        {
            float magnitudeHorizontal = Mathf.Sqrt(sqrMagnitudeHorizontal);
            float ratioHorizontal = limitHorizontal / magnitudeHorizontal;

            rb.velocity = new Vector3(rb.velocity.x * ratioHorizontal, rb.velocity.y, rb.velocity.z * ratioHorizontal);
        }

        float sqrMagnitudeVertical = rb.velocity.y * rb.velocity.y;

        if (sqrMagnitudeVertical > limitVertical * limitVertical)
        {
            float magnitudeVertical = Mathf.Sqrt(sqrMagnitudeVertical);
            float ratioVertical = limitVertical / magnitudeVertical;

            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * ratioVertical, rb.velocity.z);
        }
    }

    public static void VelocityHorizontalLimit(this Rigidbody rb, float limit)
    {
        float sqrMagnitude = (rb.velocity.x * rb.velocity.x) + (rb.velocity.z * rb.velocity.z);

        if (sqrMagnitude > limit * limit)
        {
            float magnitude = Mathf.Sqrt(sqrMagnitude);
            float ratio = limit / magnitude;

            rb.velocity = new Vector3(rb.velocity.x * ratio, rb.velocity.y, rb.velocity.z * ratio);
        }
    }

    public static void VelocityVerticalLimit(this Rigidbody rb, float limit)
    {
        float sqrMagnitude = rb.velocity.y * rb.velocity.y;

        if (sqrMagnitude > limit * limit)
        {
            float magnitude = Mathf.Sqrt(sqrMagnitude);
            float ratio = limit / magnitude;

            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * ratio, rb.velocity.z);
        }
    }

    public static void RotationResistance(this Rigidbody rb, ref Quaternion lastRotation, float rotationResistanceVelocity)
    {
        Quaternion deltaRotation = rb.transform.rotation * Quaternion.Inverse(lastRotation);

        deltaRotation.ToAngleAxis(out float angleInDegrees, out Vector3 rotationAxis);

        if (angleInDegrees > 180) angleInDegrees -= 360;

        float rotationSpeed = angleInDegrees * Time.deltaTime;

        lastRotation = rb.transform.rotation;

        if (deltaRotation == lastRotation) rotationSpeed = 0;

        float resistance = 1 + rotationSpeed * rotationResistanceVelocity;
        resistance = Mathf.Abs(resistance);

        Vector3 velocity = rb.velocity;
        float y = velocity.y;

        velocity.x /= resistance;
        velocity.z /= resistance;

        Deceleration(rb, rotationResistanceVelocity);
    }

    public static void Drag(this Rigidbody rb, float drag)
        => rb.drag = drag;

    /// <summary> Конвертирует Vector2 в Vector3 для горизонтального управления объектом </summary>
    public static Vector3 InputHorizontal(this Rigidbody rb, Vector2 input) 
        => new(input.x, 0, input.y);

    /// <summary> Конвертирует Vector2 в Vector3 для управлением камеры </summary>
    public static Vector3 InputCameraRotation(this Rigidbody rb, Vector2 input)
        => new(input.x, input.y, 0);

    /// <summary> Горизонтальное направление для движения объекта в 3D пространстве </summary>
    public static Vector3 Horizontal(this Rigidbody rb, Vector3 movement, float velocity) 
        => new(movement.x * velocity, movement.y, movement.z * velocity);

    /// <summary> Вертикальное направление для движения объекта в 3D пространстве </summary>
    public static Vector3 Vertical(this Rigidbody rb, Vector3 movement, float velocity) 
        => new(movement.x, movement.y * velocity, movement.z);

    /// <summary> Возвращает пройденную дистанцию за кадр </summary>
    public static Vector3 Distance(this Rigidbody rb) 
        => rb.velocity * Time.fixedDeltaTime;

    /// <summary> Высчитывает скорость в километрах </summary>
    public static float KmH(this Rigidbody rb)
        => rb.velocity.magnitude * KmhInMs;

    public static float KmHHorizontal(this Rigidbody rb)
        => Mathf.Sqrt(rb.velocity.x * rb.velocity.x + rb.velocity.z * rb.velocity.z) * KmhInMs;

    /// <summary> Высчитывает скорость в милях </summary>
    public static float MpH(this Rigidbody rb) 
        => KmH(rb) / KmhInMph;
}
