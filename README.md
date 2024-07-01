# Result:

- Rook: 49326 valid phone numbers
- Bishop: 2341 valid phone numbers
- Queen: 751503 valid phone numbers
- Knight: 952 valid phone numbers

## To Run the app

- Clone the repo
- Please go to lemon-edge folder
- Run
  ```sh
  dotnet build
  dotnet run
  ```
- you will find output as below
  ```sh
  Rook: 49326 valid phone numbers
  Bishop: 2341 valid phone numbers
  Queen: 751503 valid phone numbers
  Knight: 952 valid phone numbers
  ```

## To Run test cases

- Run
  ```sh
  dotnet test
  ```

## Questions?

### How do you know what you have developed is correct?

- I have written test cases against each maneuver count. As we are only concerned about the count of phone numbers.
- We can also track the list of valid phone numbers and write some valid and invalid test cases against the list.
- Something like

  ```sh
  [TestMethod]
  public void Should_Contain_Some_Valid_Numbers()
  {
      // Arrange
      IKeypad _keypad = new StandardPhoneKeypad();
      var _phoneNumberLength = 7;
      var maneuver = new BishopManeuver(_keypad, _phoneNumberLength, _startValidationRules, _maneuverValidationRules);
      var validNumbers = new List<string>{
          "9075153",
          "9075151",                                                                   // <-------------------------------------
      };

      // Act
      int count = maneuver.CalculateTotalValidNumbers();

      // Assert
      Assert.AreEqual(2341, count);
      Assert.IsTrue(validNumbers.All(x => maneuver.ValidPhoneNumbers.Contains(x)));    // <-------------------------------------
  }
  [TestMethod]
  public void Should_Not_Contain_Some_InValid_Numbers()
  {
      // Arrange
      IKeypad _keypad = new StandardPhoneKeypad();
      var _phoneNumberLength = 7;
      var maneuver = new BishopManeuver(_keypad, _phoneNumberLength, _startValidationRules, _maneuverValidationRules);
      var validNumbers = new List<string>{
          "9075152",
          "9075129",                                                                  //  <-------------------------------------
      };

      // Act
      int count = maneuver.CalculateTotalValidNumbers();

      // Assert
      Assert.AreEqual(2341, count);
      Assert.IsFalse(validNumbers.All(x => maneuver.ValidPhoneNumbers.Contains(x)));   //  <-------------------------------------
  }
  ```

  ### How can you make it more efficient?
  - Moving this keypad row and column validation to IKeypad interface to make the code clean and more modular
  
![Screenshot 2024-07-01 at 9 05 25 AM](https://github.com/keshari1arya/lemonedge-takehome-test/assets/16665888/7a0c026c-8027-4134-9a90-25433ea75814)

