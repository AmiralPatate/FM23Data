## Notes

Data sources
- [Kudos Prime](https://www.kudosprime.com/fm/carlist.php)
- [Forza Fandom wiki](https://forza.fandom.com/wiki/Forza_Motorsport_(2023)/Cars)
- [Manteo's spreadsheet](https://docs.google.com/spreadsheets/d/1ZO5HqJW_F3jBEDn9kL_YxitJs8nijTiDTxuXUHLAP9o/edit#gid=778203711)
- Manual entry

This data is mostly accurate, but I can't guarantee 100% accuracy.

Due to unit conversion and rounding, some values for power, mass and torque may be off by one from in-game data.

Some models may be missing as I manually add them as they come.

All array types use ; as separator

All numeric types use . as decimal separator

A few models are given multiple MakeID, the first MakeID is always the in-game make.

EngineConfiguration enum values include "VR" not used in-game

Induction enum values include "T4" (quad-turbo) value not used in-game.

## CSV data format

### countries.csv

string CountryCode, string Name

### divs.csv

int DivisionID, string Name

### makes.csv

int MakeID, string Name, string CountryCode

### models.csv

int ModelID, int CarOrdinal, int[] MakeID, string Name, int Year, string Nickname, string ModelExtra, int DivisionID, string[] Tags, int PI, double Speed, double Braking, double Handling, double Acceleration, int Power_kW, int Mass_kg, int Torque_Nm, enum Drivetrain [RWD,AWD,FWD], enum Engine position [R,MR,MF,F,NA], double Displacement_L, enum EngineConfiguration [I,F,V,VR,R,W,E], int Cylinders, enum Induction [NA,T,TT,DSC,T4,EV], enum ModelType [Factory,Race,Upgraded], int Doors, bool IsTopless, enum DriverPosition [L,C,R]

### track.csv

int TrackOrdinal, string EnvironmentName, string Location, string CountryCode, string TrackName, double Length_km

## Unit conversion

Unit conversion algorithm provided as C# extension class for power, mass, torque, and power-to-mass ratio.
