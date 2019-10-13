using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JNN.Models
{
    public class Pytania
    {
        private List<String> __questMaster;
        private LinkedList<String> __questShake;
        public static readonly string dataDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Data");
        private int Randomness = 1;
        private Random randGen = new Random();
        private readonly string FileName = "pytania.txt";
        private string file;

        public Pytania()
        {
            __questMaster = new List<String>(new String[]
            {   "Ja nigdy nie uciekałem przed kanarem.",
                "Ja nigdy nie życzyłem źle komuś wśród grających.",
                "Ja nigdy nie byłem zazdrosny o czyjeś 'lajki' na social mediach.",
                "Ja nigdy nie wykręcałem się od wyjścia ze znajomymi.",
                "Ja nigdy nie ukradłem znaku drogowego.",
                "Ja nigdy nie śmiałem się z grubych ludzi.",
                "Ja nigdy nie całowałem się z osobą tej samej płci.",
                "Ja nigdy nie uciekałem przed dzikim zwierzęciem/psem.",
                "Ja nigdy nie ukradłem czegoś ze sklepu.",
                "Ja nigdy nie spadłem z drzewa.",
                "Ja nigdy nie zdradziłem partnera.",
                "Ja nigdy nie tańczyłem w bieliźnie będąc sam w domu.",
                "Ja nigdy nie zmarnowałem wakacji.",
                "Ja nigdy nie szukałem partnera w internecie.",
                "Ja nigdy nie miałem wypadku samochodowego.",
                "Ja nigdy nie jeździłem pod wpływem alkoholu.",
                "Ja nigdy nikogo nie przekupiłem.",
                "Ja nigdy nie skłamałem mówiąc “kocham“.",
                "Ja nigdy nie chowałem urazy do kogoś wśród grających.",
                "Ja nigdy nie brałem twardych narkotyków.",
                "Ja nigdy nie wolałem grać na komputerze zamiast wyjść z domu.",
                "Ja nigdy nie narkotyzowałem się lekami.",
                "Ja nigdy nie miałem wątpliwości co do mojej orientacji.",
                "Ja nigdy nie uważałem któregoś z grających za chorego psychicznie.",
                "Ja nigdy nie spadłem ze schodów.",
                "Ja nigdy nie przegrałem dużej sumy pieniędzy.",
                "Ja nigdy nie zostałem okradziony.",
                "Ja nigdy nie podrywałem nauczyciela.",
                "Ja nigdy nie udawałem obcokrajowca.",
                "Ja nigdy nie miałem ścisłej diety.",
                "Ja nigdy nie spóźniłem się na ważne wydarzenie.",
                "Ja nigdy nie miałem lęku z którym nie potrafię wygrać.",
                "Ja nigdy nie byłem w toksycznym związku.",
                "Ja nigdy nie zasnąłem w kinie/teatrze.",
                "Ja nigdy nie szpanowałem pieniędzmi.",
                "Ja nigdy nie upomniałem się o pieniądze.",
                "Ja nigdy nie zgubiłem się w obcym kraju.",
                "Ja nigdy nie udawałem że piszę w telefonie, żeby uniknąć czyjegoś wzroku.",
                "Ja nigdy nie zgubiłem czyichś pieniędzy.",
                "Ja nigdy nie miałem takiej osoby której nie potrafię wybaczyć.",
                "Ja nigdy nie oszukiwałem w grach.",
                "Ja nigdy nie zmieniłem drogi, bo bałem się ciemności.",
                "Ja nigdy nie żałowałem mojego kierunku na studiach.",
                "Ja nigdy się nie zatrzasnąłem.",
                "Ja nigdy nie miałem niespełnionego marzenia.",
                "Ja nigdy nie miałem wrażenia że jestem chory psychicznie.",
                "Ja nigdy nie dolałem nikomu ukradkiem wódki do napoju.",
                "Ja nigdy nie miałem partnera tylko na jedną noc.",
                "Ja nigdy nie miałem wrażenia, że jestem alkoholikiem.",
                "Ja nigdy nie czułem, że zawiodłem przyjaciela.",
                "Ja nigdy nie podrywałem obcokrajowca.",
                "Ja nigdy nie zwymiotowałem w taksówce/uberze/autobusie.",
                "Ja nigdy nie podkochiwałem się w kimś spośród grających.",
                "Ja nigdy nie miałem problemu z akceptacją swojego wyglądu.",
                "Ja nigdy nie złamałem prawa, co mogło prowadzić do kary pozbawienia wolności.",
                "Ja nigdy nie piłem alkoholu mając mniej niż piętnaście lat.",
                "Ja nigdy nie zjadłem robaka z premedytacją.",
                "Ja nigdy nie wszedłem komuś do łazienki w nieodpowiednim momencie.",
                "Ja nigdy nie próbowałem włamać się na czyjeś konto.",
                "Ja nigdy nie stalkowałem nauczycielki.",
                "Ja nigdy nie groziłem nikomu w internecie.",
                "Ja nigdy nie wywołałem pożaru.",
                "Ja nigdy nie jechałem autostopem.",
                "Ja nigdy nie chciałem być z kimś wśród grających.",
                "Ja nigdy nie straciłem kogoś, kogo uważałem za przyjaciela.",
                "Ja nigdy nie tańczyłem całą noc.",
                "Ja nigdy nie grałem w ping-ponga czymś innym niż paletka.",
                "Ja nigdy nie pomogłem komuś zdradzić partnera.",
                "Ja nigdy nie chwaliłem się czymś czego nie mam.",
                "Ja nigdy nie kochałem się w celebrycie.",
                "Ja nigdy nie rzuciłem przekleństwem w klasie przy nauczycielu.",
                "Ja nigdy nie wytarłem plamy firanką.",
                "Ja nigdy nie wytarłem plamy skarpetą.",
                "Ja nigdy nie zepsułem myszki/klawiatury podczas gry na komputerze.",
                "Ja nigdy nie nakryłem nikogo na seksie.",
                "Ja nigdy nie chodziłem kilku dni w tej samej bieliznie.",
                "Ja nigdy nie umawiałem się na randki z wieloma różnymi osobami w tym samym tygodniu.",
                "Ja nigdy nie byłem w friendzone'ie.",
                "Ja nigdy nie obgadywałem kogoś wśród grających.",
                "Ja nigdy nie przewróciłem się w nieodpowiednim momencie.",
                "Ja nigdy nie uratowałem komuś życia.",
                "Ja nigdy nie zasnąłem w komunikacji miejskiej co poskutkowało przegapieniem przystanku.",
                "Ja nigdy nie jadłem płatków z czymś innym niż mleko.",
                "Ja nigdy nie zjadłem czegoś z podłogi.",
                "Ja nigdy nie zjadłem na randce/spotkaniu czegoś czego nie lubię, ze względu na partnera.",
                "Ja nigdy nie spaliłem czegoś na patelni, po czym to zjadłem.",
                "Ja nigdy nie odgrzałem czegoś dziwnego w mikrofali.",
                "Ja nigdy nie użyłem gumy do żucia zamiast mycia zębów.",
                "Ja nigdy nie zjadłem w lokalu i nie wyszedłem bez płacenia.",
                "Ja nigdy nie zgubiłem się w lesie.",
                "Ja nigdy nie wrzucałem dziwnych rzeczy do ognia.",
                "Ja nigdy nie sikałem do morza/jeziora/rzeki.",
                "Ja nigdy nie ukradłem komuś drinka w klubie/barze/pubie.",
                "Ja nigdy nie obudziłem się w innym mieście po imprezie.",
                "Ja nigdy nie przyszedłem do pracy/szkoły na kacu.",
                "Ja nigdy nie wymiotowałem w pracy/szkole przez wcześniejszą imprezę.",
                "Ja nigdy nie zniszczyłem czegoś, by po powierzchownej naprawie - następna osoba to zepsuła, unikając przy tym odpowiedzialności.",
                "Ja nigdy nie kąpałem się nago w morzu/rzece/jeziorze.",
                "Ja nigdy nie zniszczyłem czegoś przez przypadek w sklepie.",
                "Ja nigdy nie zostałem oszukany podczas internetowych zakupów.",
                "Ja nigdy nie robiłem sobie żartów ze znajomego w internecie anonimowo.",
                "Ja nigdy nie robiłem czegoś wbrew sobie na rzecz podrywu.",
                "Ja nigdy nie podnieciłem się w nieodpowiednim momencie.",
                "Ja nigdy nie poszedłem do szkoły/pracy w brudnym ubraniu ze świadomością tego faktu.",
                "Ja nigdy nie zataiłem jakiejś ważnej informacji przed kimś wśród grających.",
                "Ja nigdy nie kłóciłem się dalej po tym jak uświadomiłem sobie, że nie mam racji.",
                "Ja nigdy nie podglądałem czyjegoś ekranu telefonu w autobusie.",
                "Ja nigdy nie czytałem z kimś książki w komunikacji miejskiej będąc obok.",
                "Ja nigdy nie wyniosłem czegoś z pracy.",
                "Ja nigdy nie wypiłem czegoś, z czymś niespodziewanym w środku.",
                "Ja nigdy nie udawałem że paluszki to papierosy.",
                "Ja nigdy nie namalowałem komuś czegoś na twarzy podczas imprezy.",
                "Ja nigdy nie wmawiałem komuś, że po pijaku coś zrobił, ale tego nie pamięta.",
                "Ja nigdy nie udawałem, że kogoś nie słyszę/widzę, aby z nim nie rozmawiać.",
                "Ja nigdy nie przespałem całego dnia.",
                "Ja nigdy nie upiłem się sam w domu.",
                "Ja nigdy nie ryzykowałem zdrowiem, żeby komuś zaimponować.",
                "Ja nigdy nie zmarnowałem imprezy, przez czyjeś problemy.",
                "Ja nigdy nie przejęzyczyłem się w nieodpowiednim momencie.",
                "Ja nigdy nie wziąłem na siebie czyjejś winy.",
                "Ja nigdy nie przekonywałem swojego pupila, żeby coś powiedział, wierząc, że to się uda.",
                "Ja nigdy nie dawałem alkoholu czyjemuś domowemu zwierzęciu.",
                "Ja nigdy nie spóźniłem się do pracy/szkoły przez pupila.",
                "Ja nigdy nie mieszałem na jednej imprezie ponad 4 różnych alkoholi.",
                "Ja nigdy nie zjadłem czyjegoś jedzenia na imprezie.",
                "Ja nigdy nie podżegałem kogoś na imprezie do zrobienia czegoś głupiego.",
                "Ja nigdy nie wyniosłem czegoś z imprezy.",
                "Ja nigdy nie upiłem kogoś z premedytacją.",
                "Ja nigdy nie piłem na pokaz.",
                "Ja nigdy nie spałem na przystanku/dworcu.",
                "Ja nigdy nie zostałem wyniesiony przez ochronę.",
                "Ja nigdy nie sprowokowałem walki na imprezie/w klubie.",
                "Ja nigdy nie biłem się w czyimś imieniu.",
                "Ja nigdy nie żałowałem imprezy.",
                "Ja nigdy nie skakałem nad ogniskiem będąc pijanym.",
                "Ja nigdy nie upiłem się przed imprezą, przez co skończyłem ją wcześniej.",
                "Ja nigdy nie oferowałem alkoholu jako napiwek dostawcy jedzenia.",
                "Ja nigdy nie podrywałem rodzica kolegi/koleżanki.",
                "Ja nigdy nie zrobiłem zdjęcia lub nie nagrałem czegoś na imprezie, czego nie powinienem.",
                "Ja nigdy nie upuściłem jedzenia do grilla/ogniska.",
                "Ja nigdy nie spaliłem jedzenia na grillu/ognisku.",
                "Ja nigdy nie obejrzałem całego sezonu serialu jednego dnia.",
                "Ja nigdy nie spałem w wannie.",
                "Ja nigdy nie spałem pod gołym niebem.",
                "Ja nigdy nie spałem na plaży.",
                "Ja nigdy nie podglądałem kogoś, jak się przebiera.",
                "Ja nigdy nie całowałem się z kimś wśród grających.",
                "Ja nigdy nie chciałem pocałować kogoś wśród osób grających.",
                "Ja nigdy nie podrywałem dwóch osób na raz, na tej samej imprezie.",
                "Ja nigdy nie wyszedłem w trakcie imprezy do sklepu, co skończyło się niespodziewaną przygodą.",
                "Ja nigdy nie zostałem królem parkietu na imprezie.",
                "Ja nigdy nie ukradłem czegoś z wesela.",
                "Ja nigdy nie podrywałem panny/pana młodego.",
                "Ja nigdy nie byłem na festiwalu muzycznym.",
                "Ja nigdy nie zgubiłem się na festiwalu muzycznym.",
                "Ja nigdy nie poznałem kogoś na wyjeździe, o kim nie mogę przestać myśleć.",
                "Ja nigdy nie dostałem komplementu od nieznajomej/nieznajomego.",
                "Ja nigdy nie spowodowałem wypadku samochodowego.",
                "Ja nigdy nie byłem tym irytującym pasażerem.",
                "Ja nigdy nie zjeżdżałem na znaku drogowym jak na sankach.",
                "Ja nigdy sobie czegoś nie złamałem.",
                "Ja nigdy nie umawiałem się przez internet.",
                "Ja nigdy nie byłem w sytuacji, która mnie przerastała.",
                "Ja nigdy nie chciałem uderzyć kogoś wśród grających.",
                "Ja nigdy nie podkochiwałem się w partnerze mojego przyjaciela/znajomego.",
                "Ja nigdy nie doprowadziłem do czegoś więcej z przyjacielem.",
                "Ja nigdy nie wyszedłem z friendzone.",
                "Ja nigdy nie wrzuciłem nikogo do friendzone.",
                "Ja nigdy nie podrywałem na “końskie zaloty“.", 
                "Ja nigdy nie pożyczyłem od kogoś ubrania, po czym go nie zwróciłem.",
                "Ja nigdy nie miałem sytuacji w której powiedziałem o jedno słowo za dużo.",
                "Ja nigdy nie złamałem ustanowionej wcześniej diety.",
                "Ja nigdy nie złamałem obietnicy.",
                "Ja nigdy nie zaufałem komuś, na kim się potem zawiodłem.",
                "Ja nigdy nie postanowiłem skończyć z kimś znajomości.",
                "Ja nigdy nie przegadałem z kimś całej nocy.",
                "Ja nigdy nie przepuściłem dużej ilości pieniędzy na używki.",
                "Ja nigdy nie udawałem kogoś, kim nie jestem.",
                "Ja nigdy nie śmiałem się z kogoś, przez jego słabą sytuację finansową.",
                "Ja nigdy nie zjadłam całej tabliczki czekolady na raz.",
                "Ja nigdy nie myślałem, że mam depresje.",
                "Ja nigdy nie oskarżałem partnera o zdradę.",
                "Ja nigdy nie podejrzewałem partnera o zdradę.",
                "Ja nigdy nie okradłem kogoś.",
                "Ja nigdy nie przeglądałem czyjejś galerii w telefonie, bez jego zgody.",
                "Ja nigdy przez przypadek nie znalazłem nagich zdjęć znajomego w jego telefonie.",
                "Ja nigdy nie widziałem jak ktoś wywraca się na rowerze/hulajnodze.",
                "Ja nigdy nie smażyłam czegoś na opiekaczu, przez niechęć do zmywania patelni.",
                "Ja nigdy nie kłamałem odnośnie swojego wieku.",
                "Ja nigdy nie piłem w godzinach porannych alkoholu w miejscu publicznym.",
                "Ja nigdy nie myślałem nad idealną ripostą po kłótni.",
                "Ja nigdy nie fantazjowałem o byciu bohaterem jakiejś sytuacji.",
                "Ja nigdy nie zrobiłem czegoś co zmieniło moje życie.",
                "Ja nigdy nie zrobiłem czegoś czego nie powinienem z premedytacją.",
                "Ja nigdy nie ukrywałem się na imprezie.",
                "Ja nigdy nie udawałem, że kogoś słucham.",
                "Ja nigdy nie miałem fake konta na portalu społecznościowym.",
                "Ja nigdy nie jeździłem w wózku sklepowym.",
                "Ja nigdy nie jadłem zupki chińskiej z czymś innym niż woda.",
                "Ja nigdy nie rozsiałem plotki.",
                "Ja nigdy nie miałem w planach ucieczki.",
                "Ja nigdy nie byłem w radiowozie."
            });

            __questShake = MakeRandomList();
            file = Path.Combine(dataDir, FileName);
        }

        private LinkedList<String> MakeRandomList()
        {
            if (__questShake == null) __questShake = new LinkedList<string>();
            List<String> copy = new List<string>(__questMaster);

            for (int k = 0; k < Randomness; ++k)
            {
                for (int i = 0; i < copy.Count; ++i)
                {
                    int randIdx = randGen.Next() % copy.Count;
                    //zamiana elementów
                    String pom = copy[i];
                    copy[i] = copy[randIdx];
                    copy[randIdx] = pom;
                }
            }
            foreach (var Var in copy)
                __questShake.AddFirst(Var);
            return __questShake;
        }

        public String GetRandomQuestion()
        {
            String question;
            if (__questShake == null || __questShake.Count < 1)
                __questShake = MakeRandomList();
            question = __questShake.First.Value;
            __questShake.RemoveFirst();
            return question;
        }

        public void SaveQuestionsToTxt()
        {
            Directory.CreateDirectory(dataDir);
            File.WriteAllLines(file, __questShake);
        }

        public void LoadQuestionsFromTxt()
        {
            List<string> allLinesText = File.ReadAllLines(file).ToList();
            __questShake = new LinkedList<string>(allLinesText);
        }
    }
}
