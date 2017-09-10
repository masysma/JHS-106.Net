using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JHS106.Parser.Tests
{
    [TestClass]
    public class ParserStairwayTest
    {

        /*

(deftest should-parse-stairway-based-input
  (testing "Simple stairway parsing"
           (is (= {:street {:name "Kuusikatu"
                            :number "6"
                            :numberpart "6"
                            :stairway "A"}} (parse "Kuusikatu 6 A")))
           (is (= {:street {:name "Ulla Tapanisen katu"
                            :number "29"
                            :numberpart "29"
                            :stairway "D"}} (parse "Ulla Tapanisen katu 29 D")))
           (is (= {:street {:name "Ulvilantie"
                            :number "29/4"
                            :numberpart "29"
                            :building "4"
                            :stairway "K"}} (parse "Ulvilantie 29/4 K"))))
  (testing "Simple abbreviated streetname parsing"
           (is (= {:street {:name "Kuusikatu"
                            :number "6"
                            :numberpart "6"
                            :stairway "A"}} (parse "Kuusik. 6 A")))
           (is (= {:street {:name "Kuusikatu"
                            :number "6"
                            :numberpart "6"
                            :stairway "A"}} (parse "Kuusik. 6 a")))
           (is (= {:street {:name "Ulla Tapanisen katu"
                            :number "29"
                            :numberpart "29"
                            :stairway "D"}} (parse "Ulla Tapanisen k. 29 D")))
           (is (= {:street {:name "Ulla Tapanisen raitti"
                            :number "29b"
                            :numberpart "29"
                            :numberpartition "b"
                            :stairway "D"}} (parse "Ulla Tapanisen r. 29b D")))
           (is (= {:street {:name "Ulla Tapanisen raitti"
                            :number "29b"
                            :numberpart "29"
                            :numberpartition "b"
                            :stairway "D"}} (parse "Ulla Tapanisen r. 29B d")))
           (is (= {:street {:name "Ritva Valkaman tori"
                            :number "29-31b"
                            :startnumber "29"
                            :endnumber "31"
                            :numberpartition "b"
                            :stairway "D"}} (parse "Ritva Valkaman tr. 29-31B d")))
           (is (= {:street {:name "Ulvilantie"
                            :number "29/4"
                            :numberpart "29"
                            :building "4"
                            :stairway "K"}} (parse "Ulvilant. 29/4 K")))
           (is (= {:street {:name "Ulvilantie"
                            :number "29/4"
                            :numberpart "29"
                            :building "4"
                            :stairway "K"}} (parse "Ulvilant. 29/4 k")))))

(deftest should-parse-apartment-based-input
  (testing "Simple apartment parsing"
           (is (= {:street {:name "Kuusikatu"
                            :number "6"
                            :numberpart "6"
                            :stairway "A"
                            :apartment "1"
                            :apartmentnumber "1"}} (parse "Kuusikatu 6 A 1")))
           (is (= {:street {:name "Ulla Tapanisen katu"
                            :number "29"
                            :numberpart "29"
                            :stairway "D"
                            :apartment "15"
                            :apartmentnumber "15"}} (parse "Ulla Tapanisen katu 29 D 15")))
           (is (= {:street {:name "Ulvilantie"
                            :number "29/4"
                            :numberpart "29"
                            :building "4"
                            :stairway "K"
                            :apartment "825"
                            :apartmentnumber "825"}} (parse "Ulvilantie 29/4 K 825")))
           (is (= {:street {:name "Ulvilantie"
                            :number "29a/4"
                            :numberpart "29"
                            :numberpartition "a"
                            :building "4"
                            :stairway "K"
                            :apartment "825"
                            :apartmentnumber "825"}} (parse "Ulvilantie 29a/4 K 825")))
           (is (= {:street {:name "Ulvilantie"
                            :number "29a-b/4"
                            :numberpart "29"
                            :numberpartition "a-b"
                            :building "4"
                            :stairway "K"
                            :apartment "825"
                            :apartmentnumber "825"}} (parse "Ulvilantie 29a-b/4 K 825")))
           (is (= {:street {:name "Ulvilantie"
                            :number "29a-b/4"
                            :numberpart "29"
                            :numberpartition "a-b"
                            :building "4"
                            :stairway "K"
                            :apartment "825c"
                            :apartmentnumber "825"
                            :apartmentpartition "c"}} (parse "Ulvilantie 29A-B/4 k 825C")))
           (is (= {:street {:name "Ulvilantie"
                            :number "29-33b/4"
                            :startnumber "29"
                            :endnumber "33"
                            :numberpartition "b"
                            :building "4"
                            :stairway "K"
                            :apartment "825c"
                            :apartmentnumber "825"
                            :apartmentpartition "c"}} (parse "Ulvilantie 29-33B/4 k 825C")))
           (is (={ :street {:name "Gregorius IX:n tie"
                            :number "12-14"
                            :startnumber "12"
                            :endnumber "14"
                            :stairway "A"
                            :apartment "13a"
                            :apartmentnumber "13"
                            :apartmentpartition "a"}} (parse "Gregorius IX:n tie 12-14 A 13a")))
           (is (={ :street {:name "Gregorius IX:n tie"
                            :number "12-14"
                            :startnumber "12"
                            :endnumber "14"
                            :stairway "A"
                            :apartment "13a"
                            :apartmentnumber "13"
                            :apartmentpartition "a"}} (parse "Gregorius IX:n tie 12-14 a 13A"))))
  (testing "Simple leading zeroes apartment number parsing"
           (is (= {:street {:name "Kuusikatu"
                            :number "6"
                            :numberpart "6"
                            :stairway "A"
                            :apartment "1"
                            :apartmentnumber "1"}} (parse "Kuusikatu 6 A 001")))
           (is (= {:street {:name "Kuusikatu"
                            :number "6"
                            :numberpart "6"
                            :stairway "A"
                            :apartment "1c"
                            :apartmentnumber "1"
                            :apartmentpartition "c"}} (parse "Kuusikatu 6 A 001c")))
           (is (= {:street {:name "Kuusikatu"
                            :number "6"
                            :numberpart "6"
                            :stairway "A"
                            :apartment "1c"
                            :apartmentnumber "1"
                            :apartmentpartition "c"}} (parse "Kuusikatu 6 a 001C")))
           (is (= {:street {:name "Ulla Tapanisen katu"
                            :number "29"
                            :numberpart "29"
                            :stairway "D"
                            :apartment "15"
                            :apartmentnumber "15"}} (parse "Ulla Tapanisen katu 29 D 015")))
           (is (= {:street {:name "Ulla Tapanisen katu"
                            :number "29"
                            :numberpart "29"
                            :stairway "D"
                            :apartment "15a"
                            :apartmentnumber "15"
                            :apartmentpartition "a"}} (parse "Ulla Tapanisen katu 29 D 015a")))
           (is (= {:street {:name "Ulla Tapanisen katu"
                            :number "29"
                            :numberpart "29"
                            :stairway "D"
                            :apartment "15a"
                            :apartmentnumber "15"
                            :apartmentpartition "a"}} (parse "Ulla Tapanisen katu 29 d 015A"))))
  (testing "Abbreviated apartment indicating parsing (it has no stairway)"
           (is (= {:street {:name "Kuusikatu"
                            :number "6"
                            :numberpart "6"
                            :apartment "1"
                            :apartmentnumber "1"}} (parse "Kuusikatu 6 as 1")))
           (is (= {:street {:name "Ulla Tapanisen katu"
                            :number "29"
                            :numberpart "29"
                            :apartment "15"
                            :apartmentnumber "15"}} (parse "Ulla Tapanisen katu 29 as. 15")))
           (is (= {:street {:name "Ulvilav\u00E4gen"
                            :number "29/4"
                            :numberpart "29"
                            :building "4"
                            :apartment "825"
                            :apartmentnumber "825"}} (parse "Ulvilav\u00E4gen 29/4 bst 825")))
           (is (= {:street {:name "Ulvilav\u00E4gen"
                            :number "29/4"
                            :numberpart "29"
                            :building "4"
                            :apartment "825"
                            :apartmentnumber "825"}} (parse "Ulvilav\u00E4gen 29/4 bst. 825")))
           (is (= {:street {:name "Ulvilav\u00E4gen"
                            :number "2-4/4"
                            :startnumber "2"
                            :endnumber "4"
                            :building "4"
                            :apartment "825"
                            :apartmentnumber "825"}} (parse "Ulvilav\u00E4gen 2-4/4 bst. 825"))))
  (testing "Simple abbreviated streetname parsing"
           (is (= {:street {:name "Kuusikatu"
                            :number "6"
                            :numberpart "6"
                            :stairway "A"
                            :apartment "1"
                            :apartmentnumber "1"}} (parse "Kuusik. 6 A 1")))
           (is (= {:street {:name "Kuusikatu"
                            :number "6"
                            :numberpart "6"
                            :stairway "A"
                            :apartment "1"
                            :apartmentnumber "1"}} (parse "Kuusik. 6 a 1")))
           (is (= {:street {:name "Ulla Tapanisen katu"
                            :number "29"
                            :numberpart "29"
                            :stairway "D"
                            :apartment "15"
                            :apartmentnumber "15"}} (parse "Ulla Tapanisen k. 29 D 15")))
           (is (= {:street {:name "Ulla Tapanisen raitti"
                            :number "29b"
                            :numberpart "29"
                            :numberpartition "b"
                            :stairway "D"
                            :apartment "15b"
                            :apartmentnumber "15"
                            :apartmentpartition "b"}} (parse "Ulla Tapanisen r. 29b D 15b")))
           (is (= {:street {:name "Ulla Tapanisen raitti"
                            :number "29b"
                            :numberpart "29"
                            :numberpartition "b"
                            :stairway "D"
                            :apartment "15b"
                            :apartmentnumber "15"
                            :apartmentpartition "b"}} (parse "Ulla Tapanisen r. 29B d 15B")))
           (is (= {:street {:name "Ulvilantie"
                            :number "29/4"
                            :numberpart "29"
                            :building "4"
                            :stairway "K"
                            :apartment "825"
                            :apartmentnumber "825"}} (parse "Ulvilant. 29/4 K 825")))
           (is (= {:street {:name "Ulvilantie"
                            :number "29-31/4"
                            :startnumber "29"
                            :endnumber "31"
                            :building "4"
                            :stairway "K"
                            :apartment "825"
                            :apartmentnumber "825"}} (parse "Ulvilant. 29-31/4 K 825")))))

(deftest should-parse-building-based-input
  (testing "Simple building parsing"
           (is (= {:street {:name "Kuusikatu"
                            :number "6/3"
                            :numberpart "6"
                            :building "3"
                            :apartment "1"
                            :apartmentnumber "1"}} (parse "Kuusikatu 6 rak. 3 as 1")))
           (is (= {:street {:name "Kuusikatu"
                            :number "6/3"
                            :numberpart "6"
                            :building "3"
                            :apartment "1"
                            :apartmentnumber "1"}} (parse "Kuusikatu 6 rak 3 as 1")))
           (is (= {:street {:name "Kuusikatu"
                            :number "6/3"
                            :numberpart "6"
                            :stairway "C"
                            :building "3"
                            :apartment "1"
                            :apartmentnumber "1"}} (parse "Kuusikatu 6 rak. 3 C 1")))
           (is (= {:street {:name "Ulla Tapanisen katu"
                            :number "29a/2"
                            :numberpart "29"
                            :numberpartition "a"
                            :building "2"
                            :apartment "15"
                            :apartmentnumber "15"}} (parse "Ulla Tapanisen katu 29a rak. 2 15")))
           (is (= {:street {:name "Ulla Tapanisen katu"
                            :number "29a/2"
                            :numberpart "29"
                            :numberpartition "a"
                            :building "2"
                            :apartment "15"
                            :apartmentnumber "15"}} (parse "Ulla Tapanisen katu 29A rak. 2 15")))
           (is (= {:street {:name "Ulvilantie"
                            :number "29/4"
                            :numberpart "29"
                            :building "4"
                            :apartment "825"
                            :apartmentnumber "825"}} (parse "Ulvilantie 29/4 as. 825")))
           (is (={ :street {:name "Gregorius IX:n tie"
                            :number "12-14/7"
                            :startnumber "12"
                            :endnumber "14"
                            :building "7"
                            :stairway "A"
                            :apartment "13a"
                            :apartmentnumber "13"
                            :apartmentpartition "a"}} (parse "Gregorius IX:n tie 12-14 rak. 7 A 13a")))
           (is (={ :street {:name "Gregorius IX:n tie"
                            :number "12-14/7"
                            :startnumber "12"
                            :endnumber "14"
                            :building "7"
                            :stairway "A"
                            :apartment "13a"
                            :apartmentnumber "13"
                            :apartmentpartition "a"}} (parse "Gregorius IX:n tie 12-14 rak. 7 a 13A")))
           (is (={ :street {:name "Gregorius IX:n tie"
                            :number "12-14/7"
                            :startnumber "12"
                            :endnumber "14"
                            :building "7"
                            :stairway "\u00D6"
                            :apartment "13\u00E5"
                            :apartmentnumber "13"
                            :apartmentpartition "\u00E5"}} (parse "Gregorius IX:n tie 12-14 rak. 7 \u00F6 13\u00C5")))
           (is (={ :street {:name "Gregorius IX:n tie"
                            :number "12-14d/7"
                            :startnumber "12"
                            :endnumber "14"
                            :numberpartition "d"
                            :building "7"
                            :stairway "\u00D6"
                            :apartment "13\u00E5"
                            :apartmentnumber "13"
                            :apartmentpartition "\u00E5"}} (parse "Gregorius IX:n t. 12-14D rak. 7 \u00F6 13\u00C5")))
           (is (={ :street {:name "Gallen-Kallelan katu"
                            :number "12-14d/7"
                            :startnumber "12"
                            :endnumber "14"
                            :numberpartition "d"
                            :building "7"
                            :stairway "\u00D6"
                            :apartment "13\u00E5"
                            :apartmentnumber "13"
                            :apartmentpartition "\u00E5"}} (parse "Gallen-Kallelan k. 12-14D rak. 7 \u00F6 13\u00C5")))))

(deftest should-do-simple-parsing
  (is (= {:street {:name "Kuusikatu"}} (simple-parse "Kuusikatu")))
  (is (= {:street {:name "Kuusikeijun aukio"}} (simple-parse "Kuusikeijun aukio")))
  (is (= {:street {:name "Kuusikeijun aukio"}} (simple-parse "Kuusikeijun auk.")))
  (is (= {:street {:name "Kuusikatu"
                   :number "6"}} (simple-parse "Kuusikatu 6")))
  (is (= {:street {:name "Kuusikatu"
                   :number "6"
                   :stairway "A"}} (simple-parse "Kuusikatu 6 A")))
  (is (= {:street {:name "Kuusikatu"
                   :number "6"
                   :stairway "A"
                   :apartment "1"}} (simple-parse "Kuusikatu 6 A 001")))
  (is (= {:street {:name "Ulvilantie"
                   :number "29/4"
                   :stairway "K"
                   :apartment "825"}} (simple-parse "Ulvilant. 29/4 K 825")))
  (is (= {:street {:name "Ulvilantie"
                   :number "29/4"
                   :stairway "K"
                   :apartment "25"}} (simple-parse "Ulvilant. 29/4 K 025")))
  (is (= {:street {:name "Ulla Tapanisen raitti"
                   :number "29b"
                   :stairway "D"
                   :apartment "15b"}} (simple-parse "Ulla Tapanisen r. 29b D 15b")))
  (is (= {:street {:name "Ulla Tapanisen raitti"
                   :number "29b-c"
                   :stairway "D"
                   :apartment "15b"}} (simple-parse "Ulla Tapanisen r. 29b-c D 15b")))
  (is (= {:street {:name "Ulla Tapanisen katu"
                   :number "29b/1"
                   :stairway "D"
                   :apartment "15b"}} (simple-parse "Ulla Tapanisen k. 29b rak. 1 D 15b")))
  (is (={ :street {:name "Gregorius IX:n tie"
                   :number "12-14"
                   :stairway "A"
                   :apartment "13a"}} (simple-parse "Gregorius IX:n tie 12-14 A 13a")))
  (is (={ :street {:name "Gregorius IX:n tie"
                   :number "12-14"
                   :stairway "A"
                   :apartment "13a"}} (simple-parse "Gregorius IX:n tie 12-14 a 13A")))
  (is (={ :street {:name "Gregorius IX:n tie"
                   :number "12-14/2"
                   :stairway "A"
                   :apartment "13a"}} (simple-parse "Gregorius IX:n tie 12-14 rak. 2 A 13a")))
  (is (={ :street {:name "Gregorius IX:n tie"
                   :number "12-14/2"
                   :stairway "\u00C4"
                   :apartment "13\u00F6"}} (simple-parse "Gregorius IX:n tie 12-14 rak. 2 \u00C4 13\u00F6")))
  (is (={ :street {:name "Gallen-Kallelan katu"
                   :number "12-14/2"
                   :stairway "A"
                   :apartment "13a"}} (simple-parse "Gallen-Kallelan k. 12-14 rak. 2 A 13a"))))

(deftest should-parse-dot-containing-street-names
  (is (={ :street {:name "K. H. Wiikin katu"}} (simple-parse "K. H. Wiikin katu")))
  (is (={ :street {:name "K. H. Wiikin katu"}} (simple-parse "K. H. Wiikin k.")))
  (is (={ :street {:name "K. H. Wiikin katu"
                   :number "3"
                   :stairway "A"
                   :apartment "1"}} (simple-parse "K. H. Wiikin katu 3 A 1")))
  (is (={ :street {:name "K. H. Wiikin katu"
                   :number "3"
                   :stairway "A"
                   :apartment "1"}} (simple-parse "K. H. Wiikin k. 3 A 1")))
  (is (={ :street {:name "K. H. Wiikin katu"}} (parse "K. H. Wiikin katu")))
  (is (={ :street {:name "K. H. Wiikin katu"}} (parse "K. H. Wiikin k.")))
  (is (={ :street {:name "K. H. Wiikin katu"
                   :number "3/2"
                   :numberpart "3"
                   :building "2"
                   :apartment "1"
                   :apartmentnumber "1"}} (parse "K. H. Wiikin k. 3 rak. 2 as 1 ")))
  (is (={ :street {:name "K.H. Wiikin katu"}} (parse "K.H. Wiikin katu")))
  (is (={ :street {:name "K.H. Wiikin katu"}} (parse "K.H. Wiikin k.")))
  (is (={ :street {:name "K.H. Wiikin katu"
                   :number "3/2"
                   :numberpart "3"
                   :building "2"
                   :apartment "1"
                   :apartmentnumber "1"}} (parse "K.H. Wiikin k. 3 rak. 2 as 1 "))))

(deftest should-unabbreviate-streetname
  (doseq [v abbreviations]
    (is (= (str "Rosvo" (name (key v))) (unabbreviate (str "Rosvo" (val v)))) (str (val v) " => " (name (key v))))
    (is (= (str "Tark'ampujan" (name (key v))) (unabbreviate (str "Tark'ampujan" (val v)))) (str (val v) " => " (name (key v))))
    (is (= (str "\u00C4mm\u00E4l\u00E4n" (name (key v))) (unabbreviate (str "\u00C4mm\u00E4l\u00E4n" (val v)))) (str (val v) " => " (name (key v))))
    (is (= (str "Gregorius IX:n " (name (key v))) (unabbreviate (str "Gregorius IX:n " (val v)))) (str (val v) " => " (name (key v))))))

(deftest should-not-do-parsing-with-forbidden-characters
  (is (= {} (parse "This is email address with some text lappeenranta@virhe.fi")))
  (is (= {:street nil} (simple-parse "This is email address with some text lappeenranta@virhe.fi")))
  (is (= {} (parse "another regexp bomb on invalid input with extremely long street 13:")))
  (is (= {:street nil} (simple-parse "another regexp bomb on invalid input with extremely long street 13:")))
  (is (= {} (parse "another regexp bomb on invalid input with extremely long street 13.")))
  (is (= {:street nil} (simple-parse "another regexp bomb on invalid input with extremely long street 13.")))
  (is (= {} (parse "another regexp bomb on invalid input with extremely long street 13-")))
  (is (= {:street nil} (simple-parse "another regexp bomb on invalid input with extremely long street 13-")))
  (is (= {} (parse "another regexp bomb on invalid input with extremely long street :13")))
  (is (= {:street nil} (simple-parse "another regexp bomb on invalid input with extremely long street :13")))
  (is (= {} (parse "another regexp bomb on invalid input with extremely long street .13")))
  (is (= {:street nil} (simple-parse "another regexp bomb on invalid input with extremely long street .13")))
  (is (= {} (parse "another regexp bomb on invalid input with extremely long street -13")))
  (is (= {:street nil} (simple-parse "another regexp bomb on invalid input with extremely long street -13")))
  (is (= {} (parse "another regexp bomb on invalid input with extremely long street 13: A 15c")))
  (is (= {:street nil} (simple-parse "another regexp bomb on invalid input with extremely long street 13: A 15c")))
  (is (= {} (parse "another regexp bomb on invalid input with extremely long street 13. A 15c")))
  (is (= {:street nil} (simple-parse "another regexp bomb on invalid input with extremely long street 13. A 15c")))
  (is (= {} (parse "another regexp bomb on invalid input with extremely long street 13- A 15c")))
  (is (= {:street nil} (simple-parse "another regexp bomb on invalid input with extremely long street 13- A 15c")))
  (is (= {} (parse "another regexp bomb on invalid input with extremely long street 13 :")))
  (is (= {:street nil} (simple-parse "another regexp bomb on invalid input with extremely long street 13 :")))
  (is (= {} (parse "another regexp bomb on invalid input with extremely long street 13 .")))
  (is (= {:street nil} (simple-parse "another regexp bomb on invalid input with extremely long street 13 .")))
  (is (= {} (parse "another regexp bomb on invalid input with extremely long street 13 -")))
  (is (= {:street nil} (simple-parse "another regexp bomb on invalid input with extremely long street 13 -")))
  (is (= {} (parse "another regexp bomb on invalid input with extremely long street 13 :A")))
  (is (= {:street nil} (simple-parse "another regexp bomb on invalid input with extremely long street 13 :A")))
  (is (= {} (parse "another regexp bomb on invalid input with extremely long street 13 .A")))
  (is (= {:street nil} (simple-parse "another regexp bomb on invalid input with extremely long street 13 .A")))
  (is (= {} (parse "another regexp bomb on invalid input with extremely long street 13 -A")))
  (is (= {:street nil} (simple-parse "another regexp bomb on invalid input with extremely long street 13 -A")))
  (is (= {} (parse "another regexp bomb on invalid input with extremely long street 13 . A 15c")))
  (is (= {:street nil} (simple-parse "another regexp bomb on invalid input with extremely long street 13 . A 15c")))
  (is (= {} (parse "another regexp bomb on invalid input with extremely long street 13 : A 15c")))
  (is (= {:street nil} (simple-parse "another regexp bomb on invalid input with extremely long street 13 : A 15c")))
  (is (= {} (parse "another regexp bomb on invalid input with extremely long street 13 - A 15c")))
  (is (= {:street nil} (simple-parse "another regexp bomb on invalid input with extremely long street 13 - A 15c")))
  (is (= {} (parse "another regexp bomb on invalid input with extremely long street 13 .A 15c")))
  (is (= {:street nil} (simple-parse "another regexp bomb on invalid input with extremely long street 13 .A 15c")))
  (is (= {} (parse "another regexp bomb on invalid input with extremely long street 13 :A 15c")))
  (is (= {:street nil} (simple-parse "another regexp bomb on invalid input with extremely long street 13 :A 15c")))
  (is (= {} (parse "another regexp bomb on invalid input with extremely long street 13 -A 15c")))
  (is (= {:street nil} (simple-parse "another regexp bomb on invalid input with extremely long street 13 -A 15c")))
  (is (= {} (parse "another regexp bomb on invalid input with extremely long street 13-A 15c")))
  (is (= {:street nil} (simple-parse "another regexp bomb on invalid input with extremely long street 13-A 15c"))))    
 *          * */
    }
}
