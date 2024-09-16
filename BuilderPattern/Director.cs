namespace BuilderPattern;

public class Director
{
    public Computer Construct(Builder builder)
    {
        return builder.BuildComputer();
    }
}
