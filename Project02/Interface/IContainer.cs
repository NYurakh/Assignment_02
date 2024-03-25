public interface IContainer
{

double Depth{get;}
double MaxPayload{get;}
string SerialNumber{get;}
double Height{get;}
string Type{get;}
double CargoMass{get; set;}
double TareWeight{get;}

void LoadCargo(double weigth);
void EmptyCargo();
void InfoOutput();
string CreateNumber(string type);


}

