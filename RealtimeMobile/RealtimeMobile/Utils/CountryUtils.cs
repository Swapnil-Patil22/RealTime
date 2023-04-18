using System;
using RealtimeMobile.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace RealtimeMobile.Utils
{
	public class CountryUtils
    {
        public static List<RegionInfo> GetCountriesByIso3166()
        {
            var countries = new List<RegionInfo>();
            foreach (var culture in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                var info = new RegionInfo(culture.LCID);
                if (countries.All(p => p.Name != info.Name))
                    countries.Add(info);
            }
            return countries.OrderBy(p => p.EnglishName).ToList();
        }

        public static CountryModel GetCountryModelByName(string countryName)
        {
            //var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            var isoCountries = GetCountriesByIso3166();
            var regionInfo = isoCountries.FirstOrDefault(c => c.EnglishName == countryName);
            return regionInfo != null
                ? new CountryModel
                {
                    //CountryCode = phoneNumberUtil.GetCountryCodeForRegion(regionInfo.TwoLetterISORegionName).ToString(),
                    CountryName = regionInfo.EnglishName,
                    FlagUrl = $"https://hatscripts.github.io/circle-flags/flags/{regionInfo.TwoLetterISORegionName.ToLower()}.svg",
                }
                : new CountryModel
                {
                    CountryName = countryName
                };
        }
    }
}