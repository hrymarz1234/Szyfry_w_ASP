using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Szyfry
    {
        [Required]
        public string tekst { get; set; }
        [Required]
        public int przesuniecie { get; set; }
        public bool taknie { get; set; }
        public static string szyfr_cezara(string tekst, int przesuniecie)
        {
            string tab = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż";
            string tab2 = "AĄBCĆDEĘFGHIJKLŁMNŃOÓPQRSŚTUVWXYZŹŻ";
            string pom = "";
            string pom2 = "";

            for (int i = 0; i < tekst.Length; i++)
            {
                if (tekst[i] != ' ')
                {
                    pom += tekst[i];
                }

            }
            for (int l = 0; l < pom.Length; l++)
            {
                for (int j = 0; j < tab2.Length; j++)
                {
                    if (pom[l] == tab2[j])
                    {
                        pom2 += tab[j];
                    }
                    else if (pom[l] == tab[j])
                    {
                        pom2 += tab[j];
                    }

                }

            }
            pom = "";
            for (int k = 0; k < pom2.Length; k++)
            {
                for (int y = 0; y < tab.Length; y++)
                {

                    if (pom2[k] == tab[y])
                        pom += tab[(y + przesuniecie) % 35];
                }
            }
            return pom;
        }
        public static string szyfr_polibiusza(string tekst, bool taknie)
        {
            string tab = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż";
            string tab2 = "AĄBCĆDEĘFGHIJKLŁMNŃOÓPQRSŚTUVWXYZŹŻ";
            string pom = "";
            long a = 0;

            for (int k = 0; k < tekst.Length; k++)
            {
                for (int j = 0; j < 5; j++)
                {

                    for (int i = 0; i < 7; i++)
                    {
                        int liczba = (j * 7) + i;

                        if (tekst[k] == tab[liczba] || tekst[k] == tab2[liczba])
                        {
                            pom += ((j + 1) * 10) + (i + 1);
                        }
                    }
                }

            }
            a = long.Parse(pom);
            if (taknie == true)
            {
                return string.Format("{0:x}", a);
            }
            else
                return pom;

        }
        public static string szyfr_homofoniczny(string tekst)
        {
            

            string tab = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż";
            string tab2 = "AĄBCĆDEĘFGHIJKLŁMNŃOÓPQRSŚTUVWXYZŹŻ";
            string[,] tabszyfr =  { {"a","ą","b","c","ć","d","e","ę","f","g","h","i","j","k","l","ł","m","n","ń","o","ó","p","q","r","s","ś","t","u","v","w","x","y","z","ź","ż"},
                {"59","35","63","27","60","04","36","14","20","65","50","66","09","34","28","10","19","69","18","33","49","44","32","37","16","51","03","21","13","67","12","11","48","23","54"},
                {"15","35","63","05","60","61","47","14","20","65","50","41","53","56","38","10","64","43","18","68","49","07","32","37","16","51","58","55","13","67","57","70","45","23","54"},
                {"06","35","63","27","60","04","42","14","20","65","50","39","09","34","28","10","19","29","18","30","49","44","32","01","02","51","03","21","13","08","12","11","17","23","54"},
                {"22","35","63","05","60","61","24","14","20","65","50","25","53","56","38","10","64","43","18","26","49","44","32","01","02","51","03","55","13","08","12","70","17","23","54"},
                {"71","35","63","05","60","61","24","14","20","65","50","40","09","34","28","10","19","29","18","30","49","44","32","01","02","51","03","21","13","08","12","11","17","23","54"}};

            string pom = "";
            string pom2 = "";

            for (int i = 0; i < tekst.Length; i++)
            {
                if (tekst[i] != ' ')
                {
                    pom += tekst[i];
                }

            }
            for (int l = 0; l < pom.Length; l++)
            {
                for (int j = 0; j < tab2.Length; j++)
                {
                    if (pom[l] == tab2[j])
                    {
                        pom2 += tab[j];
                    }
                    else if (pom[l] == tab[j])
                    {
                        pom2 += tab[j];
                    }

                }

            }
            pom = "";
            for (int k = 0; k < pom2.Length; k++)
            {
                for (int v = 0; v < 35; v++)
                {
                    Random random = new Random();


                    int losowaLiczba = random.Next(1, 6);
                    if ((pom2[k]).ToString() == tabszyfr[0, v])
                        pom += tabszyfr[losowaLiczba, v];

                }
            }
            return pom;
        }
    }
}
