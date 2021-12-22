# Introduction 

.NET implementation of Finland's postal address parsing, based on [JHS-106 recommendation](http://www.jhs-suositukset.fi/suomi/jhs106).

This implementation is a based on the original Clojure implementation (https://github.com/tomimas/JHS-106).

# Getting Started
You can install the library from nuget.org.

	PM> Install-Package JHS-106.Parser

After installing parser can be called normally

	using JHS106.Parser;

	// ...

	var jhs106Parser = new Parser();
    ParsedAddress  = jhs106Parser.Parse("Mannerheimintie 97a A 52\n00280 HELSINKI ");

# Examples

	address = jhs106Parser.Parse("Mannerheimintie 97a A 52\n00280 HELSINKI ");
	
	// address:
	//      StreetName           "Mannerheimintie"   
	//      Number               "97a"   
	//      NumberPart           "97"    
	//      NumberPartition      "a" 
	//      Stairway             "A" 
	//      Apartment            "52"    
	//      ApartmentNumber      "52"    
	//      PostalCode           "00280" 
	//      PostOffice           "HELSINKI"  
	
	
	address = jhs106Parser.Parse("Kauppakatu 25-27, 40100 JYVÄSKYLÄ ");
	
	// address:
	//      StreetName  "Kauppakatu"    
	//      Number      "25-27" 
	//      StartNumber "25"    
	//      EndNumber   "27"    
	//      PostalCode  "40100" 
	//      PostOffice  "JYVÄSKYLÄ" 
	
	
	address = jhs106Parser.Parse("Ulvilantie 29/4 K 825, FI-00350 HELSINKI");
	
	// address:
	//      StreetName      "Ulvilantie"    
	//      Number          "29/4"  
	//      NumberPart      "29"    
	//      Building        "4" string
	//      Stairway        "K" 
	//      Apartment       "825"   
	//      ApartmentNumber "825"   
	//      PostalCode      "00350" 
	//      PostOffice      "HELSINKI"  

For more usage examples, please see test methods from source code for reference.

# Contribute
If you notice an error or would liek to contribute, please feel free make pull requests.

## License

Copyright &copy; 2017 Matti Sysmäläinen

Distributed under the Eclipse Public License.
