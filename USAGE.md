# Usage

This program can be run as a Windows application or on the command line.

When running on the Command Line (for automating conversion of a number of
files), you can get the help by executing from a command line:

```cmd
EAExport /?

EAExport.exe /o|/output:<outputfile> [/r|/root:<guid>] [/f|/format:<format>]
             <inputfile>

Version: 1.4.0.0

Options
  /o | /output <outputfile>
    Specify the output filename after parsing the input.
  /r | /root <eaid>
    The EA ID of the object that is the root element, to start dumping from.
    You can get this easily when starting the GUI, by selecting the element
    and noting the 'Identifier'.
  /f | /format <format>
    Defines the format to use.
     CSVHTML - HTML formatted CSV files
     CSVTEXT - Plain text formatted CSV files

  <inputfile>
    The XML file from Enterprise Architect (XMI 1.1) to parse for requirements.
```
