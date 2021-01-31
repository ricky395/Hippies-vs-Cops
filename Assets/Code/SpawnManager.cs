using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    class CopsData
    {
        /* TipoCop, PosiciónY, VelocidadX */
        public int[] cData = new int[3];
        public float points;
    };

    [SerializeField] Transform copsPool;

    [SerializeField] GameObject[] cops;

    public List<GameObject> aliveCops = new List<GameObject>();
    List<CopsData> copsData = new List<CopsData>();

    bool firstSpawn = true;

    /* TipoCop, PosiciónY, VelocidadX */

    public static int[] minValues = { 0, 0, 1};
    public static int[] maxValues = { 2, 4, 10};

    public static int hordeSize = 10;
    public static float elegibleParents = 0.25f;
    public static float mutationRatio = 0.05f;


    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        int copsCount = 0;

        while (copsCount < hordeSize)
        {
            ++copsCount;

            CopsData data = new CopsData();

            if (firstSpawn)
            {
                for (int i = 0; i < minValues.Length; ++i)
                {
                    int rnd = Random.Range(minValues[i], maxValues[i] + 1);
                    data.cData[i] = rnd;
                }
            }
            else
            {
                // Spawn según aptitud
            }

            // Guardamos los datos del policía
            copsData.Add(data);

            // Instanciamos el policía       PUNTO DE SPAWN
            //Instantiate(cops[data.cData[0]],                , Quaternion.identity, copsPool);

            //Seteamos velocidad del poli

            yield return new WaitForSeconds(Random.Range(1, 3));
        }

        firstSpawn = false;
        hordeSize += 2;
    }
}
