using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportLib.Web
{
    public class ApiResponseArray : IEnumerable<ApiResponse>
    {
        public readonly JArray _array;

        public ApiResponseArray(JArray array) => _array = array;

        public ApiResponse this[object key]
        {
            get
            {
                var token = _array[key];

                return new(token);
            }
        }

        public int Count => _array.Count;

        public IEnumerator<ApiResponse> GetEnumerator() =>
            _array.Select(i => new ApiResponse(i)).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
