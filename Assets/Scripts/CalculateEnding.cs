using UnityEngine;
using static UnityEngine.CullingGroup;
using static UnityEngine.Rendering.DebugUI;

public class CalculateEnding: MonoBehaviour
{
    public static bool Poster = false;
    public static bool Poster2 = false;
    public static bool Manicure = false;
    public static bool BishoujoFigures = false;
    public static bool wigs = false;
    public static bool wigs2 = false;
    public static bool BedCleaning = false;
    public static bool Shoes = false;
    public static bool PlantsDrop = false;
    public static bool Water = false;
    public static bool dirt = false;
    public static bool Laundry = false;
    public static bool MaggiCups = false;
    public static bool Snacks = false;
    public static bool Socks = false;
    public static bool MakeUp = false;
    public static bool DirtyDish = false;
    public static bool Fridge = false;
    public static bool StudyTable = false;

    private CountDownTimer timer;
    private bool wasEnding = false;
    SelectionQuestion SelectionQuestion = new SelectionQuestion();

    void Start()
    {
        timer = FindObjectOfType<CountDownTimer>();
        if (timer == null)
        {
            Debug.LogError("CountDownTimer not found in the scene.");
        }
    }
    public static void UpdateItemStatus(ItemType itemType, bool status)
    {
        switch (itemType)
        {
            case ItemType.Poster:
                Poster = status;
                break;
            case ItemType.Poster2:
                Poster2 = status;
                break;
            case ItemType.Manicure:
                Manicure = status;
                break;
            case ItemType.BishoujoFigures:
                BishoujoFigures = status;
                break;
            case ItemType.wigs:
                wigs = status;
                break;
            case ItemType.wigs2:
                wigs2 = status;
                break;
            case ItemType.BedCleaning:
                BedCleaning = status;
                break;
            case ItemType.Shoes:
                Shoes = status;
                break;
            case ItemType.PlantsDrop:
                PlantsDrop = status;
                break;
            case ItemType.Water:
                Water = status;
                break;
            case ItemType.dirt:
                dirt = status;
                break;
            case ItemType.Laundry:
                Laundry = status;
                break;
            case ItemType.MaggiCups:
                MaggiCups = status;
                break;
            case ItemType.Snacks:
                Snacks = status;
                break;
            case ItemType.Socks:
                Socks = status;
                break;
            case ItemType.MakeUp:
                MakeUp = status;
                break;
            case ItemType.DirtyDish:
                DirtyDish = status;
                break;
            case ItemType.Fridge:
                Fridge = status;
                break;
            case ItemType.StudyTable:
                StudyTable = status;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timer != null && timer.isTimeLimit)
        {
            if (!wasEnding)
            {
                Ending();
            }
        }
    }

    public void Ending()
    {
        if (Poster && Poster2 && Manicure && BishoujoFigures && wigs && wigs2 && BedCleaning && Shoes && MakeUp && PlantsDrop && Water
            && dirt && Laundry && MaggiCups && Snacks && Socks && DirtyDish && Fridge && StudyTable)
        {
            //ending 1
            //GameManager.ending++;
            GameManager.instance.UnlockEnding("Ending1");
        }
        else if (Poster && Poster2 && BishoujoFigures && wigs && wigs2 && BedCleaning && Shoes && MakeUp && StudyTable)
        {
            //ending2
            GameManager.instance.UnlockEnding("Ending2");
        }
        else if (PlantsDrop && Water && dirt && Laundry && MaggiCups && Snacks && Socks && DirtyDish && Fridge)
        {
            //ending5
            GameManager.instance.UnlockEnding("Ending5");
        }
        else if (Poster && Poster2 && BishoujoFigures && wigs && wigs2 && BedCleaning && Shoes && PlantsDrop && Water
            && dirt && Laundry && MaggiCups && Snacks && Socks && DirtyDish && Fridge && StudyTable)
        {
            //ending6
            GameManager.instance.UnlockEnding("Ending6");
        }
        else if(SelectionQuestion.YesOrNo == true)
        {
            if (Poster && Poster2 && Manicure && BishoujoFigures && wigs && wigs2 && BedCleaning && Shoes && MakeUp && PlantsDrop && Water
            && dirt && Laundry && MaggiCups && Snacks && Socks && DirtyDish && Fridge && StudyTable)
            {
                //ending 4
                Debug.Log("TimeOut");
                GameManager.instance.UnlockEnding("Ending4");
            }
        }
        else
        {
            //ending3
            Debug.Log("Bad Ending");
            wasEnding = true;
            GameManager.instance.UnlockEnding("Ending3");
        }
    }
}
