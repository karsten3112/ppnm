DIR = $(HOME)/repos/PPNM/matlib/complex

Out.txt: main.exe
	mono main.exe

main.exe: main.cs cmath.dll
	mcs main.cs -reference:cmath.dll -out:main.exe -target:exe

cmath.dll: $(DIR)/cmath.cs $(DIR)/complex.cs
	mcs -target:library -out:./cmath.dll $^

