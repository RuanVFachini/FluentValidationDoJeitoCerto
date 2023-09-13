using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleTeste
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var validator = new Validator();

            try
            {
                await validator.ValidateAndThrowAsync(new Li());
            }
            catch (FluentValidation.ValidationException ex)
            {
                ex.Errors.ToList().ForEach(e =>
                {
                    Console.WriteLine(e.ErrorMessage);
                });
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}
