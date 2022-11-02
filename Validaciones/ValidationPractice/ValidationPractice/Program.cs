
using ValidationPractice.Model;
using ValidationPractice.Validator;

Console.WriteLine("Hello, World!");


//var client = new Client
//{
//    Id= 1,
//    LastName = "Perez",
//    Discount = 10
//};

//var clientValidator = new ClientValidator();
//var validationResult= clientValidator.Validate(client);

//Console.WriteLine(validationResult);




//Mostrar todos los mensajes de validacion

//client.Id = 0;

//var clientValidatorMessage = new ClientValidatorMessage();
//var validationResultMessage = clientValidatorMessage.Validate(client);

//Console.WriteLine();
//Console.WriteLine("Mostrar mensajes de todas las validaciones");
//if (!validationResultMessage.IsValid)
//{
//    foreach (var item in validationResultMessage.Errors)
//    {
//        Console.WriteLine(item.ErrorMessage);
//    }
//}




//Validaciones encadenadas

//client.Id = 55;
//client.Name = "foo";

//var clientValidatorEncadenar = new ClientValidatorEncadenar();
//var validationResultEncadenar = clientValidatorEncadenar.Validate(client);

//Console.WriteLine();
//Console.WriteLine("Resultado validaciones encadenadas");
//if (!validationResultEncadenar.IsValid)
//{
//    foreach (var item in validationResultEncadenar.Errors)
//    {
//        Console.WriteLine(item.ErrorMessage);
//    }
//}




//Reglas personalizadas
var clientValidacionPersonalizada = new Client
{
    Id = 1,
    Discount = 10,
    Address = new Address()
};
 
var customRuleValidator = new ClientValidatorCustomRules();
var validationRulesResult = customRuleValidator.Validate(clientValidacionPersonalizada);

Console.WriteLine();
Console.WriteLine("Resultado validaciones con reglas personalizadas");
if (!validationRulesResult.IsValid)
{
    foreach (var item in validationRulesResult.Errors)
    {
        Console.WriteLine(item.ErrorMessage);
    }
}