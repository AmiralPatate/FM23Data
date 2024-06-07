## Notes

Data sources
- [Kudos Prime](https://www.kudosprime.com/fm/carlist.php)
- [Forza Fandom wiki](https://forza.fandom.com/wiki/Forza_Motorsport_(2023)/Cars)
- [Manteo's spreadsheet](https://docs.google.com/spreadsheets/d/1ZO5HqJW_F3jBEDn9kL_YxitJs8nijTiDTxuXUHLAP9o/edit#gid=778203711)
- Manual entry

This data is as accurate as it is.

Some models may be missing as I manually add them as they come.

Due to unit conversion and rounding, some values for power, mass and torque may be off by one from in-game data.

All numeric types use `.` as decimal separator.

## CSV data format

### countries.csv
string CountryCode, string Name

### modelexport.csv
int CarOrdinal, string Make, string Name, int Year, string Nickname, string Division, string CountryCode, int PI, double Speed, double Braking, double Handling, double Acceleration, int Power_kW, int Mass_kg, int Torque_Nm, enum Drivetrain [RWD,AWD,FWD], enum EnginePosition [R,MR,MF,F,NA], double Displacement_L, enum EngineConfiguration [I,F,V,VR,R,W,E], int Cylinders, enum Induction [NA,T,TT,DSC,T4,EV], enum ModelType [Factory,Race,Upgraded], int Doors, bool IsTopless, enum DriverPosition [L,C,R]

### track.csv
int TrackOrdinal, string EnvironmentName, string Location, string CountryCode, string TrackName, double Length_km

---

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

---

## Standalone Toolbox

C# .NET Framework 4.8 executable with 4 tools:

- **Track**: Pick a track, get a random one. Estimates the number of laps for a variety of distances and race times.
  
- **Telemetry**: Reads telemetry packets on port 56535 (hardcoded). Displays lap times, designed for Rivals mode. Copies to clipboard the best time of each run. Pull handbrake 3 times in a lap to mark time as dirty. Dirty laps are marked as negative time. Visit telemetry/timeattack.txt for a log of all times.
  
- **Color conv.**: Converts hex or RGB color codes into Forza coordinates. Third decimal place in parentheses for reasons. Can save and load custom colors.
  
- **Unit conv.**: Converts mass, power, power-to-mass, and torque to/from various units.
