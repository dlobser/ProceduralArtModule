;FLAVOR:Marlin
;TIME:25266
;Filament used: 33.2601m
;Layer height: 0.2
;MINX:17.499
;MINY:17.499
;MINZ:0.2
;MAXX:217.499
;MAXY:217.499
;MAXZ:2
;Generated with Cura_SteamEngine 4.11.0
M82 ;absolute extrusion mode
; Ender 3 Custom Start G-code
G92 E0 ; Reset Extruder
G28 ; Home all axes
;LAYER_COUNT:10
;LAYER:0
M107
;MESH:cube.obj
G0 F6000 X17.499 Y17.499 Z0.2
;TYPE:FILL
G0 F0 X0 Y0
G0 X220 Y0
G0 X220 Y220
G0 X0 Y220
G0 X0 Y0