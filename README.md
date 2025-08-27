Coding Assessment for Dye & Durham

This C# solution is for the coding assesment sent.  The solution has to 3 projects to give an ideea about an aproach (without going too far with it!).  
All source files have general documentation/commments that should be self-explanatory.  The projects are:
- name-sorter
- name-sorter.tests

name-sorter:
This is the main project that contains the source-files for the basic console application.
The project can be built/run directly using the supplied example test file ("unsorted-names-list.txt"), or published using the publish profile I've included.  
NOTE: The default publish profile is just set to build a x64 self-contained exe located in the bin/Release/net8.0/publish directory.

name-sorter.services:
This is the library that contains the source-files for the "services/classes" used/shared by the main application and the ""tests".

name-sorter.tests:
This is the project used for basic unit-tests. The test are just basic unit test to give an indication of my approach.
NOTE: I have deliberately not used/included integration tests for file-related classes though.

NOTES/ASSUMPTIONS:
1) Since there was no real requirement on how invalid names are to be handled, I've simply just returned the name in the overall list of sorted names, prefixed and sorted with an error message as the names at the start of the list.  
These invalid names are by default NOT written to the output file ("sorted-names-list.txt") as well.  Refer to the SaveInvalidNames property in the Application class.

2) File IO:
	a) Exceptions are only caught, logged and echoed/displayed back to the console.  No attempt is made to pre-check for valid/existing paths, etc.
	b) Only the host file-system is used.  However, both the FileReader and/or FileWriter can be overridden classes to create "Fakes/Mocks", if required for unit-testing.
	c) The FileReader and FileWriter classes can be used to implement their Read/Write functionality onto other hosts/platforms, if required.

