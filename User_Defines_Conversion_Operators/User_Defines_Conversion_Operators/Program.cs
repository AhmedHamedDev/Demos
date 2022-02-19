


using User_Defines_Conversion_Operators;

Guid id = Guid.NewGuid();

// implicit conversion
UserId userId = id; 
Guid guild = userId;


// explicit conversion
// implicit conversion can be used for explicit alse
UserId userId1 = (UserId)id;
Guid guild1 = (Guid)userId1;