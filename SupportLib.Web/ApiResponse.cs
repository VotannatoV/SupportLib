using Newtonsoft.Json.Linq;

namespace SupportLib.Web
{
    public sealed class ApiResponse
    {
        private readonly JToken _token;

        public ApiResponse(JToken token) => _token = token;

        public string RawJson { get; set; }

        public ApiResponse this[object key]
        {
            get
            {
                if (_token is JArray && key is string)
                {
                    return null;
                }

                var token = _token[key];

                return token != null && token.Type != JTokenType.None ? new(token) : null;
            }
        }

        public bool HasToken() => _token != null && _token.HasValues;

        public bool ContainsKey(string key)
        {
            if (!(_token is JObject))
            {
                return false;
            }

            var token = _token[key];

            return token != null;
        }

        public static implicit operator ApiResponseArray(ApiResponse response)
        {
            if (response == null)
            {
                return null;
            }

            return response._token is JArray array ? new(array) : null;
        }

        public override string ToString() => _token.ToString();

        #region System types

        public static implicit operator bool(ApiResponse response) =>
            (bool)response._token;

        public static implicit operator bool?(ApiResponse response) =>
            response != null ? (bool)response._token : null;

        public static implicit operator byte(ApiResponse response) =>
            (byte)response._token;

        public static implicit operator byte?(ApiResponse response) =>
            response != null ? (byte)response._token : null;

        public static implicit operator sbyte(ApiResponse response) =>
            (sbyte)response._token;

        public static implicit operator sbyte?(ApiResponse response) =>
            response != null ? (sbyte)response._token : null;

        public static implicit operator char(ApiResponse response) =>
            (char)response._token;

        public static implicit operator char?(ApiResponse response) =>
            response != null ? (char)response._token : null;

        public static implicit operator decimal(ApiResponse response) =>
            (decimal)response._token;

        public static implicit operator decimal?(ApiResponse response) =>
            response != null ? (decimal)response._token : null;

        public static implicit operator double(ApiResponse response) =>
            (double)response._token;

        public static implicit operator double?(ApiResponse response) =>
            response != null ? (double)response._token : null;

        public static implicit operator float(ApiResponse response) =>
            (float)response._token;

        public static implicit operator float?(ApiResponse response) =>
            response != null ? (float)response._token : null;

        public static implicit operator int(ApiResponse response) =>
            (int)response._token;

        public static implicit operator int?(ApiResponse response) =>
            response != null ? (int)response._token : null;

        public static implicit operator uint(ApiResponse response) =>
            (uint)response._token;

        public static implicit operator uint?(ApiResponse response) =>
            response != null ? (uint)response._token : null;

        public static implicit operator nint(ApiResponse response) =>
            (nint)response._token;

        public static implicit operator nint?(ApiResponse response) =>
            response != null ? (nint)response._token : null;

        public static implicit operator nuint(ApiResponse response) =>
            (nuint)response._token;

        public static implicit operator nuint?(ApiResponse response) =>
            response != null ? (nuint)response._token : null;

        public static implicit operator long(ApiResponse response) =>
            (long)response._token;

        public static implicit operator long?(ApiResponse response) =>
            response != null ? (long)response._token : null;

        public static implicit operator ulong(ApiResponse response) =>
            (ulong)response._token;

        public static implicit operator ulong?(ApiResponse response) =>
            response != null ? (ulong)response._token : null;

        public static implicit operator short(ApiResponse response) =>
            (short)response._token;

        public static implicit operator short?(ApiResponse response) =>
            response != null ? (short)response._token : null;

        public static implicit operator string(ApiResponse response) =>
            response != null ? (string)response._token : null;

        #endregion
    }
}
