using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CareControl_Service.Contract
{
    public class SingleModelResponse<TModel>
    {
        #region Public Properties



        [JsonIgnore]
        public bool IsError { get; set; }

        public TModel Model { get; set; }

        #endregion Public Properties
    }
}
