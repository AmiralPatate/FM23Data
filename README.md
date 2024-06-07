# What is this?

This is data and tools for Forza Motorsport 2023.

The main data is the `modelexport.csv` file. It contains a bunch of information about models in-game, compiled into one file. See below for more details.

StandaloneToolbox is a small program that does a few useful things, as detailed below. It uses a different data format, also detailed below.

----

# Main data

[`modelexport.csv`](https://github.com/AmiralPatate/FM23Data/blob/main/modelexport.csv)

Data sources
- [Kudos Prime](https://www.kudosprime.com/fm/carlist.php)
- [Forza Fandom wiki](https://forza.fandom.com/wiki/Forza_Motorsport_(2023)/Cars)
- [Manteo's spreadsheet](https://docs.google.com/spreadsheets/d/1ZO5HqJW_F3jBEDn9kL_YxitJs8nijTiDTxuXUHLAP9o/edit#gid=778203711)
- Manual entry

This data is as accurate as it is.

Some models may be missing as I manually add them as they come.

Due to unit conversion and rounding, some values for power, mass and torque may be off by one from in-game data.

All numeric types use `.` as decimal separator.

All array types use `;` as separator.

## CSV data format

### modelexport.csv
int CarOrdinal, string Make, string Name, int Year, string Nickname, string Division, string CountryCode, int PI, double Speed, double Braking, double Handling, double Acceleration, int Power_kW, int Power_PS, int Power_hp, int Mass_kg, int Mass_lb, int Torque_Nm, int Torque_ftlb, enum Drivetrain [RWD,AWD,FWD], enum EnginePosition [R,MR,MF,F,NA], double Displacement_L, enum EngineConfiguration [I,F,V,VR,R,W,E], int Cylinders, enum Induction [NA,T,TT,DSC,T4,EV], enum ModelType [Factory,Race,Upgraded], int Doors, bool IsTopless, enum DriverPosition [L,C,R]

---

# Standalone Toolbox

C# .NET Framework 4.8 executable with the following functions:

- **Models**: View, edit, create model information. Use at your own risk. Requires `divs.csv`, `makes.csv`, `country.csv` and `models.csv`.

- **Makes**: View, edit, create make information. Use at your own risk. Requires `divs.csv`, `makes.csv`, `country.csv` and `models.csv`.

- **Countries**: View, edit, create country information. Use at your own risk. Requires `divs.csv`, `makes.csv`, `country.csv` and `models.csv`.

- **Divisions**: View division information. Use at your own risk. Requires `divs.csv`, `makes.csv`, `country.csv` and `models.csv`.
    
- **Search**: Search models with pretty much any filter. Requires `divs.csv`, `makes.csv`, `country.csv` and `models.csv`.

- **Tracks**: Pick a track or get a random one. Estimates the number of laps for a variety of distances and race times. Requires `tracks.csv` and `country.csv`.
  
- **Telemetry**: Reads telemetry packets on port 56535 (hardcoded). Displays lap times, designed for Rivals mode. Copies to clipboard the best time of each run. Pull handbrake 3 times in a lap to mark time as dirty. Dirty laps are marked as negative time. Open telemetry/timeattack.txt for a log of all times recorded. Optionally equires `tracks.csv` and `country.csv` for track information, and `divs.csv`, `makes.csv`, `country.csv` and `models.csv` for car information.
  
- **Colours**: Converts hex or RGB color codes into Forza coordinates. Third decimal place in parentheses for reasons. Can save and load custom colors.
  
- **Units**: Converts mass, power, power-to-mass, and torque to/from various units.

## CSV data format

### countries.csv
string CountryCode, string Name

### divs.csv
int DivisionID, string Name

### makes.csv
int MakeID, string Name, string CountryCode

### models.csv
int ModelID, int CarOrdinal, int[] MakeID, string Name, int Year, string Nickname, string ModelExtra, int DivisionID, string[] Tags, int PI, double Speed, double Braking, double Handling, double Acceleration, int Power_kW, int Mass_kg, int Torque_Nm, enum Drivetrain [RWD,AWD,FWD], enum EnginePosition [R,MR,MF,F,NA], double Displacement_L, enum EngineConfiguration [I,F,V,VR,R,W,E], int Cylinders, enum Induction [NA,T,TT,DSC,T4,EV], enum ModelType [Factory,Race,Upgraded], int Doors, bool IsTopless, enum DriverPosition [L,C,R]

### track.csv
int TrackOrdinal, string EnvironmentName, string Location, string CountryCode, string TrackName, double Length_km

## Enum details

### Drivetrain
- RWD: Rear-wheel drive
- AWD: All-wheel drive
- FWD: Front-wheel drive

### EnginePosition
- R: Rear
- MR: Mid rear (appears in-game as Mid)
- MF: Mid front (does not appear in-game, not used)
- F: Front
- NA: Not applicable (does not appear in-game, not used)

### EngineConfiguration
- I: Inline
- F: Flat
- V: V engine
- VR: VR engine (does not appear in-game, used in some Volkswagen models)
- R: Rotary
- W: W engine
- E: Electric

### Induction
- NA: Naturally aspirated
- T: Turbo
- TT: Twin-turbo
- DSC: Supercharged (positive displacement or centrifugal)
- T4: Quad-turbo (does not appear in-game, used for Bugatti W16 engines)
- EV: Electric / other not applicable

### ModelType
- Race: Race-spec model
- Factory: Production model
- Upgraded: Stock-upgraded production model, e.g. Forza Edition

### DriverPosition
- L: Left
- C: Centre
- R: Right
