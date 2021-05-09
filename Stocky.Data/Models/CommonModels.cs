using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stocky.Data.Models
{
    #region Result with generic parameter
    public class Result<T>
    {
        public Result()
        {
            Errors = new List<string>();
            Success = false;
        }
        public T Data { get; set; }
        public bool Success { get; set; }
        public ICollection<string> Errors { get; set; }
        public string ErrorMessage { get; set; }

        public void AddErrors(List<string> errors)
        {
            if (errors.Count > 0)
            {
                Success = false;
                Errors = errors;
            }
        }
        public void AddError(string errorMessage)
        {
            Success = false;
            ErrorMessage = errorMessage;
        }

    }
    #endregion

    #region Result without parameter
    public class Result
    {
        public Result()
        {
            Errors = new List<string>();
            Success = false;
        }
        public object Data { get; set; }
        public bool Success { get; set; }
        public ICollection<string> Errors { get; set; }
        public string ErrorMessage { get; set; }

        public void AddErrors(List<string> errors)
        {
            if (errors.Count > 0)
            {
                Success = false;
                Errors = errors;
            }
        }
        public void AddError(string errorMessage)
        {
            Success = false;
            ErrorMessage = errorMessage;
        }

    }
    #endregion
   
    //public class UnprocessableEntity : ObjectResult
    //{
    //    public UnprocessableEntity(ModelStateDictionary modelState) : base(new SerializableError(modelState))
    //    {
    //        if (modelState == null)
    //        {
    //            throw new ArgumentNullException(nameof(modelState));
    //        }

    //        StatusCode = 422;
    //    }
    //}

    public abstract class ResourceParameters
    {
        const int maxPageSize = 100;

        private int _pageSize = 10;
        public int PageNo { get; set; } = 1;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

        public string SearchQuery { get; set; } = "";
        public string Key { get; set; } = "";
        public string OrderBy { get; set; } = "";
    }

    public class AuditModel
    {
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [MaxLength(256)]
        public string CreatedBy { get; set; }

        [MaxLength(256)]
        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public DateTime? CreatedDate { get; set; }

        //[StringLength(450)]
        //public string SharedKey { get; set; }
    }
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
