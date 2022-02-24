using Strategy_Pattern;

Context context = new Context(new OperationAdd());
Console.WriteLine("10 + 5 = " + context.executeStrategy(10, 5));

context = new Context(new OperationSubstract());
Console.WriteLine("10 - 5 = " + context.executeStrategy(10, 5));

context = new Context(new OperationMultiply());
Console.WriteLine("10 * 5 = " + context.executeStrategy(10, 5));