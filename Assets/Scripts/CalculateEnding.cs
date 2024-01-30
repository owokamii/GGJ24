using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public TMP_Text boolChecks;

    private CountDownTimer timer;
    public TextMeshProUGUI endingText;
    public bool wasEnding = false;
    SelectionQuestion selectionQuestion = new SelectionQuestion();
    public GameObject EndingPanel;
    public Image pictureShowingImage;
    public Sprite endingSprite1;
    public Sprite endingSprite2;
    public Sprite endingSprite3;
    public Sprite endingSprite4;
    public Sprite endingSprite5;
    public Sprite endingSprite6;

    void Start()
    {

        selectionQuestion = GetComponent<SelectionQuestion>();
        wasEnding = false;
        GameObject pictureShowingObj = GameObject.Find("EndingPanel/PictureShowing");
        if (pictureShowingObj != null)
        {
            pictureShowingImage = pictureShowingObj.GetComponent<Image>();
            if (pictureShowingImage == null)
            {
                Debug.LogError("Image component on PictureShowing not found.");
            }
        }
        else
        {
            Debug.LogError("PictureShowing GameObject not found.");
        }

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
        Debug.Log("YesOrNo2: " + selectionQuestion.YesOrNo);
        BoolChecks();

        if (timer != null && timer.isTimeLimit)
        {
            if (!wasEnding)
            {
                EndingPanel.SetActive(true);
                Ending();
            }
        }
    }

    public void Ending()
    {
        if (selectionQuestion.YesOrNo == true) // confirmed maid ending
        {
            if (Poster && Poster2 && Manicure && BishoujoFigures && wigs && wigs2 && BedCleaning && Shoes && MakeUp && PlantsDrop && Water
            && dirt && Laundry && MaggiCups && Snacks && Socks && DirtyDish && Fridge && StudyTable)
            {
                //ending 4 - Cleaned Everything - while wearing maid outfit == correct
                if (pictureShowingImage != null)
                {
                    pictureShowingImage.sprite = endingSprite4;
                    endingText.text = "I swear, it’s a gift from a friend!";
                    wasEnding = true;
                }
                GameManager.instance.UnlockEnding("Ending4");
            }
            else
            {
                //ending 3 - did not clean anything or is wrong == correct
                if (pictureShowingImage != null)
                {
                    pictureShowingImage.sprite = endingSprite3;
                    endingText.text = "I was kicked out of the house afterward.";
                    Debug.Log("Bad Ending");
                    wasEnding = true;
                }
                GameManager.instance.UnlockEnding("Ending3");
                GameManager.instance.PrintEndings();
            }
        }
        else
        {
            if (Poster && Poster2 && BishoujoFigures && wigs && wigs2 && BedCleaning && PlantsDrop && Water
                && dirt && Laundry && MaggiCups && Snacks && Socks && DirtyDish && Fridge && StudyTable && !(Manicure&&MakeUp &&Shoes))
            {
                //ending 6 - cleaned everything except gifts
                if (pictureShowingImage != null)
                {
                    pictureShowingImage.sprite = endingSprite6;
                    endingText.text = "Pretty sure today is mother’s day…";
                    wasEnding = true;
                }
                GameManager.instance.UnlockEnding("Ending6");
            }
            else if (Poster && Poster2 && Manicure && BishoujoFigures && wigs && wigs2 && BedCleaning && Shoes && MakeUp && StudyTable && !(PlantsDrop && Water && dirt && Laundry && MaggiCups && Snacks && Socks && DirtyDish && Fridge))
            {
                //ending 2 - cleaned everything except girly
                if (pictureShowingImage != null)
                {
                    pictureShowingImage.sprite = endingSprite2;
                    endingText.text = "Nothing suspicious here…";
                    wasEnding = true;
                }
                GameManager.instance.UnlockEnding("Ending2");
            }
            else if (PlantsDrop && Water && dirt && Laundry && MaggiCups && Snacks && Socks && DirtyDish && Fridge && !(Poster && Poster2 && Manicure && BishoujoFigures && wigs && wigs2 && BedCleaning && Shoes && MakeUp && StudyTable))
            {
                //ending 5 - cleaned everything except dirty
                if (pictureShowingImage != null)
                {
                    pictureShowingImage.sprite = endingSprite5;
                    endingText.text = "We look like sisters!";
                    wasEnding = true;
                }
                GameManager.instance.UnlockEnding("Ending5");
            }
            else if (Poster && Poster2 && Manicure && BishoujoFigures && wigs && wigs2 && BedCleaning && Shoes && MakeUp && PlantsDrop && Water
            && dirt && Laundry && MaggiCups && Snacks && Socks && DirtyDish && Fridge && StudyTable)
            {
                //ending 1 - cleaned everything
                if (pictureShowingImage != null)
                {
                    pictureShowingImage.sprite = endingSprite1;
                    endingText.text = "I cleaned everything, but Mom never came by.";
                    wasEnding = true;
                }
                GameManager.instance.UnlockEnding("Ending1");
            }
            else
            {
                //ending 3 - did not clean anything or is wrong
                if (pictureShowingImage != null)
                {
                    pictureShowingImage.sprite = endingSprite3;
                    endingText.text = "I was kicked out of the house afterward.";
                    Debug.Log("Bad Ending");
                    wasEnding = true;
                }
                GameManager.instance.UnlockEnding("Ending3");
                GameManager.instance.PrintEndings();
            }
        }
    }

    public void BoolChecks()
    {
        boolChecks.text = "Poster: " + Poster.ToString() + "\nPoster2: " + Poster2.ToString() + "\nManicure: " + Manicure.ToString() + "\nFigures: " + BishoujoFigures.ToString() + "\nWigs: " + wigs.ToString() + "\nWigs2:" + wigs2.ToString() +
        "\nBedCleaning: " + BedCleaning.ToString() + "\nShoes: " + Shoes.ToString() + "\nPlants: " + PlantsDrop.ToString() + "\nWater: " + Water.ToString() + "\nDirt: " + dirt.ToString() + "\nLaundry: " + Laundry.ToString() + "\nMaggicups: " + MaggiCups.ToString() +
        "\nSnacks: " + Snacks.ToString() + "\nSocks: " + Socks.ToString() + "\nMakeUp: " + MakeUp.ToString() + "\nDirtyDish: " + DirtyDish.ToString() + "\nFridge: " + Fridge.ToString() + "\nStudyTable: " + StudyTable.ToString();
    }
}
