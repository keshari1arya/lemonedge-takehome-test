// See https://aka.ms/new-console-template for more information
using lemon_edge.Models;



var keypad = new StandardPhoneKeypad();
PhoneNumberGenerator generator = new PhoneNumberGenerator(keypad, 7);
generator.GenerateAndPrintValidPhoneNumbers();