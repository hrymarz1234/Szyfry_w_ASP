namespace WebApplication1.Models
{
    public class OdSzyfry : Szyfry
    {

        public static string odszyfrowanie_cezara(string tekst, int przesuniecie)
        {
            string tab = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż";
            string pom = "";
            for (int k = 0; k < tekst.Length; k++)
            {
                for (int y = 0; y < tab.Length; y++)
                {

                    if (tekst[k] == tab[y])
                    {
                        if ((y - przesuniecie) % 35 < 0)
                            pom += tab[35 + ((y - przesuniecie) % 35)];
                        else
                            pom += tab[(y - przesuniecie) % 35];
                    }
                }
            }
            return pom;
        }

        public static string odszyfrowanie_polibiusza(string tekst, bool taknie)
        {
            string tab = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż";
            string znak = "";
            string text = "";
            long pom = 0;
            if (taknie == true)
            {
                pom = Convert.ToInt64(tekst, 16);
                znak = pom.ToString();
            }
            else
                znak = tekst;
            int znak2 = 0;
            int znak3 = 0;
            int liczba;

            for (int i = 0; i < znak.Length; i = i + 2)
            {
                for (int j = 0; j < 2; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        znak2 = int.Parse((znak[(i + j)]).ToString());
                        znak2 = (znak2 - 1) * 7;

                    }
                    else
                    {
                        znak3 = int.Parse(znak[(i + j)].ToString());
                        znak3 = (znak3 - 1);
                    }


                }
                liczba = znak2 + znak3;
                text += tab[liczba];
                liczba = 0;

            }
            return text;

        }
        public static string odszyfrowanie_homofoniczne(string tekst)
        {
            string[,] tabszyfr =  { {"a","ą","b","c","ć","d","e","ę","f","g","h","i","j","k","l","ł","m","n","ń","o","ó","p","q","r","s","ś","t","u","v","w","x","y","z","ź","ż"},
                {"59","35","63","27","60","04","36","14","20","65","50","66","09","34","28","10","19","69","18","33","49","44","32","02","62","51","03","21","13","57","12","11","48","23","54"},
                {"15","35","63","05","60","61","47","14","20","65","50","41","53","56","38","10","64","43","18","68","49","07","32","37","16","51","58","55","21","67","57","56","45","23","54"},
                {"06","35","63","27","60","04","42","14","20","65","50","39","09","34","28","10","19","29","18","30","49","44","32","01","02","51","03","21","13","08","12","11","17","23","54"},
                {"22","35","63","05","60","61","24","14","20","65","50","25","53","56","38","10","64","43","18","26","49","44","32","01","02","51","03","21","13","08","12","11","17","23","54"},
                {"38","35","63","05","60","61","24","14","20","65","50","40","09","34","28","10","19","29","18","30","49","44","32","01","02","51","03","21","13","08","12","11","17","23","54"}};
            string znak = "";
          

            znak = tekst;
            string znak2="";
            string  kod="";
            int liczba=0;
            

            for (int i = 0; i < znak.Length; i = i + 2)
            {
                for (int j = 0; j < 2; j++)
                {
                    znak2 += znak[i + j];
                }

                for (int l = 1; l < 6; l++)
                {
                    int k = 0;
                    do
                    {
                        if (znak2 == tabszyfr[l, k])
                            kod += tabszyfr[l, k];
                        else
                            k++;
                    } while (znak2 != tabszyfr[l, k] || k < 35);
                }

            }
            return kod;

        }
    }
}