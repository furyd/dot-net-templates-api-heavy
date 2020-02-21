namespace Template.Services.Abstractions.Models.Immutable
{
    public class Example
    {
        public string ExampleProperty { get; }

        public Example(string exampleProperty)
        {
            ExampleProperty = exampleProperty;
        }
    }
}