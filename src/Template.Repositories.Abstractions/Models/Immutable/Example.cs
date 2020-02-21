namespace Template.Repositories.Abstractions.Models.Immutable
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