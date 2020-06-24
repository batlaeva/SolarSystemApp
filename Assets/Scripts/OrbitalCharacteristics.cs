using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalCharacteristics : MonoBehaviour
{
    //точка вращения
    public Transform pivot;
    //вращающийся объект
    public Transform rotatingObject;
    //наклон орбиты oтнocитeльнo coлнeчнoгo эквaтopa
    public byte orbitalInclination = 0; 
    //Большая полуось (semiMajorAxis) в 8 раз меньше, км
    public float a = 0f;
    //Эксцентриситет орбиты
    public float eccentricity = 0f;
    //Standard gravitational parameter
    public float gravitationalParameter = 1f;
    //смещение
    public float centerOffset = 0f;
    //Малая полуось
    float b = 0f;
    //Разница м/у объектами
    Vector3 difference = new Vector3(0f, 0f, 0f);
    float dist = 0f;
    float orbitSpeed = 0f;
    //от 0 до 1, на 360 градусов
    float orbitProgress = 0f;

    float angle = 0f;
    float x = 0f;
    float y = 0f;

    public Animator animator;

    void Start()
    {
        //наклон 
        transform.localRotation = Quaternion.Euler(orbitalInclination, 0f, 0f);
        //вычисление малой полуоси
        b = a * Mathf.Sqrt(1 - eccentricity * eccentricity);

        setOrbitObjectPosition();
    }

    void Update()
    {
        if (animator.GetBool("isMoveSS")) {
            calculateOrbitalSpeed();
            orbitProgress += Time.deltaTime * orbitSpeed;
            orbitProgress %= 1f;
            setOrbitObjectPosition();
        }
    }

    void calculateOrbitalSpeed(){
        difference = pivot.localPosition - rotatingObject.localPosition;
        dist = difference.magnitude;
        orbitSpeed = Mathf.Sqrt(Mathf.Abs(gravitationalParameter * (2 / dist - 1 / a)));//ABS???
    }

    void setOrbitObjectPosition() {
        calculatePosition();
        rotatingObject.localPosition = new Vector3(pivot.localPosition.x - x + centerOffset, rotatingObject.localPosition.y, pivot.localPosition.z - y); //y-up
    }

    void calculatePosition() {
        angle = Mathf.Deg2Rad * 360f * orbitProgress;
        x = Mathf.Sin(angle) * a;
        y = Mathf.Cos(angle) * b;
    }
}
