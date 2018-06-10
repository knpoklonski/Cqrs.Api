using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CqrsApi.Infrastructure
{
    public class CollectionResult<T>
    {
        public CollectionResult(IEnumerable<T> data, int skip, int top, string baseLink)
        {
            Top = top;
            Skip = skip;
            Data = data;

            InitPageLinks(baseLink, skip, top);
        }

        public int Top { get; }
        public int Skip { get; }
        public IEnumerable<T> Data { get; set; }
        public string PrevLink { get; set; }
        public string NextLink { get; set; }

        private void InitPageLinks(string url, int skip, int top)
        {
            NextLink = top > 0 ? GeneratePageLink(url, skip + top, top).ToString() : null;

            var prevSkip = skip - top;
            if (prevSkip < 0)
                prevSkip = 0;

            PrevLink = top > 0 ? GeneratePageLink(url, prevSkip, top).ToString() : null;
        }

        private static Uri GeneratePageLink(string requestedUrl, int skip, int top)
        {
            var builder = new UriBuilder(new Uri(requestedUrl));
            string queryString = builder.Query;

            queryString = SetQueryParameterNumericValue(queryString, "skip", skip);
            queryString = SetQueryParameterNumericValue(queryString, "top", top);

            builder.Query = queryString;
            return builder.Uri;
        }

        private static string SetQueryParameterNumericValue(string query, string param, int value)
        {
            query = Regex
                .Replace(query, $@"&?{param}=[-\+]*\d*", string.Empty, RegexOptions.IgnoreCase)
                .Replace("?&", "?");

            if (query.Length > 1)
                query += "&";

            if (value > 0)
                query += $"{param}={value}";

            if (query.EndsWith("&"))
                query = query.Substring(0, query.Length - 1);

            if (query.EndsWith("?"))
                query = query.Substring(0, query.Length - 1);

            return query;
        }
    }
}