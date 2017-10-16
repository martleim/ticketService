using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Business
{
    public class BaseManager : IDisposable
    {
        public const string AustraliaDefaultTimeZoneId = "AUS Eastern Standard Time";
        public const string ChinaDefaultTimeZoneId = "China Standard Time";
        public const string IsoDateFormat = "yyyy-MM-ddTHH\\:mm\\:ss.fffzzz";

        public DateTimeOffset ConvertUtcLocalDateTimeOffset(DateTime utcTime, string timeZoneId)
        {
            TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            var localDatetime = ConvertUtcToLocalDateTime(utcTime, timeZoneId);
            DateTimeOffset dateAndOffset = new DateTimeOffset(localDatetime, tz.GetUtcOffset(localDatetime));
            return dateAndOffset;
        }


        public DateTimeOffset AddLocalDateTimeOffset(DateTime localDateTime, string timeZoneId)
        {
            TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            DateTimeOffset dateAndOffset = new DateTimeOffset(localDateTime, tz.GetUtcOffset(localDateTime));
            return dateAndOffset;
        }

        public DateTime ConvertUtcToLocalDateTime(DateTime utc, string timeZoneId)
        {
            TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            return TimeZoneInfo.ConvertTime(utc, tz);
        }

        public virtual void Dispose()
        {
        }

        #region NLOG
        /*
         
        private const string errorMessage = "An error has occured check the error log file for more details.";

        protected static Logger logger = LogManager.GetCurrentClassLogger();
        protected void logMessage(string message)
        {
            logger.Info(message);
        }

        protected void logTrace(string message)
        {
            logger.Trace(message);
        }

        protected void logError(string message, Exception exception)
        {
            this.logMessage(errorMessage);
            this.logTrace(errorMessage);
            if (exception.InnerException != null)
            {
                logger.Error(exception.InnerException, message + " " + exception.StackTrace);
            }
            else
            {
                logger.Error(exception, message + " " + exception.StackTrace);
            }

        }

          
         */
        #endregion

    }

    public class BusinessLogicException : Exception
    {
        public BusinessLogicException(string message, Exception innerException) : base(message, innerException) { }
    }

    public static class Extensions
    {

        public static bool ContainsCI(this string source, string toCheck)
        {
            if (string.IsNullOrEmpty(toCheck) || string.IsNullOrEmpty(source))
                return false;

            return source.ToLower().Contains(toCheck.ToLower());
        }

    }

    public class Validator<T>
    {

        public Validator()
        {
            TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(typeof(T)), typeof(T));
        }

        public List<string> Validate(T model)
        {
            List<string> errors = new List<string>();

            PropertyInfo[] propInfos = typeof(T).GetProperties();
            propInfos.ToList().ForEach(p => {
                foreach (object attr in p.GetCustomAttributes())
                {
                    if (attr is ValidationAttribute)
                    {
                        var validatorAtt = ((ValidationAttribute)attr);
                        if (!validatorAtt.IsValid(p.GetValue(model)))
                            errors.Add(validatorAtt.ErrorMessage);
                    }
                }
                /*if(p.PropertyType.GetInterface(typeof(IEnumerable<>).FullName)!=null && p.PropertyType.GetGenericArguments().Length==1){
                    Type constructedClass = (typeof(Validator<>)).MakeGenericType(p.PropertyType.GenericTypeArguments[0]);
                    object validator = Activator.CreateInstance(constructedClass);
                    var val=p.GetValue(model);
                }
                if(p.GetValue(model)!=null){
                    Type constructedClass = (typeof(Validator<>)).MakeGenericType(new Type[] { p.PropertyType });
                    MethodInfo validate = constructedClass.GetMethod("Validate");
                    object validator = Activator.CreateInstance(constructedClass);
                    var ret = validate.Invoke(validator, new object[]{p.GetValue(model)});
                }*/
            });

            return errors;
        }

    }
}
