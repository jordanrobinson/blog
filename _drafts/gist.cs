using System;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

using Sitecore.Data.Items;
using Sitecore.Data.Validators;
using Sitecore.StringExtensions;

namespace Your.Project.Configuration.AuthoringExperience.General
{
    /// <summary>
    /// File Extension Validator class. Validates that a file given has a given extension.
    /// </summary>
    [Serializable]
    public class FileExtensionValidator : StandardValidator
    {
        public FileExtensionValidator(SerializationInfo info, StreamingContext context)
            : base(info, context) {}

        public FileExtensionValidator() {}

        public override string Name
        {
            get { return "Must match extension given"; }
        }

        protected override ValidatorResult GetMaxValidatorResult()
        {
            return GetFailedResult(ValidatorResult.Error);
        }

        protected override ValidatorResult Evaluate()
        {
            string extension;
            Parameters.TryGetValue("Extension", out extension);

            //get media ID from the controlValidationValue and discard the rest
            var mediaId = Regex.Replace(ControlValidationValue, ".*mediaid=\"{([-a-zA-Z0-9]*).*", "$1");
            
            var media = (MediaItem) Context.Database.GetItem(mediaId);

            if (!extension.IsNullOrEmpty() && media != null && media.Extension.ToLower().Equals(extension.ToLower()))
            {
                return ValidatorResult.Valid;
            }

            Text = string.Format("\"{0}\" doesn't match extension \"{1}\"", this.GetFieldDisplayName(), extension);
            return GetFailedResult(ValidatorResult.Warning);
        }
    }
}
