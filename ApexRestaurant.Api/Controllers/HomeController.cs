using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;


namespace ApexRestaurant.Api.Controller {
    [Route ("/")]
    public class HomeController : ControllerBase {
        [HttpGet]
        [Route ("/")]
        public IActionResult Index () {
            // get base_uri, e.g. https://localhost:5001
            var base_uri = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";

            // available api endpoints list
            var endpoints = new List<string>{"customer", "menu", "menuitem", "meal", "mealdish", "staff", "staffrole"};

            // taag (text to ascii art generator)
            var hello = @"
o      o                                o     o               8         
8      8                                8b   d8               8         
8      8 .oPYo. .oPYo. oPYo.   .oPYo.   8`b d'8 .oPYo. .oPYo. 8  .o     
8  db  8 8oooo8 .oooo8 8  `'   .oooo8   8 `o' 8 .oooo8 Yb..   8oP'      
`b.PY.d' 8.     8    8 8       8    8   8     8 8    8   'Yb. 8 `b.     
 `8  8'  `Yooo' `YooP8 8       `YooP8   8     8 `YooP8 `YooP' 8  `o. 88 
::..:..:::.....::.....:..:::::::.....:::..::::..:.....::.....:..::...`P 
::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::.:
::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
                                                      
.oPYo.   o                  .oPYo.         d'b        
8        8                  8              8          
`Yooo.  o8P .oPYo. o    o   `Yooo. .oPYo. o8P  .oPYo. 
    `8   8  .oooo8 8    8       `8 .oooo8  8   8oooo8 
     8   8  8    8 8    8        8 8    8  8   8.     
`YooP'   8  `YooP8 `YooP8   `YooP' `YooP8  8   `Yooo' 
:.....:::..::.....::....8 :::.....::.....::..:::.....:
:::::::::::::::::::::ooP'.::::::::::::::::::::::::::::
:::::::::::::::::::::...::::::::::::::::::::::::::::: ";

            
            var api_text = "";
            foreach (var endpoint in endpoints)
            {
                api_text += Environment.NewLine + $"{base_uri}/api/{endpoint}";
            }

            
            return Ok (hello + api_text);
        }
    }
}