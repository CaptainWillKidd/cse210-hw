public class Retangle : Shape{
    private double _lenght;
    private double _width;

    public Retangle(double lenght, double width){
        _lenght = lenght;
        _width = width;
    }

    public override double GetArea()
    {
        return _lenght * _width;
    }
}