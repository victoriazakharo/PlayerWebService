using System;
using System.ComponentModel.DataAnnotations;

namespace PlayerWebService
{
    [Serializable]
        public class PlayerFilter
        {
            //[Display(Name = "Weight From:")]
            public int? WeightFrom { get; set; }

            //[Display(Name = "Weight To:")]
            public int? WeightTo { get; set; }

            //[Display(Name = "Height From:")]
            public int? HeightFrom { get; set; }

            //[Display(Name = "Height To:")]
            public int? HeightTo { get; set; }

            //[Display(Name = "Position:")]
            public string Position { get; set; }

            //[Display(Name = "Birth Year From:")]
            //[Range(1000, 2015)]
            public int? YearFrom { get; set; }
    }
}