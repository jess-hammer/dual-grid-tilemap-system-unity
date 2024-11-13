# ✨👯 Dual-grid tilemap system in Unity 👯✨

#### This is a demo of how I implemented a dual-grid tilemap system in Unity 2023.1.11f1

👀 Looking for an alternative implementation? 👀
- Check out [DualGrid](https://github.com/skner-dev/DualGrid) by skner! It is structured as a Unity package, is compatible with RuleTiles and has automatic tile setup.

### Demo
Run the project, then use the mouse buttons to place or remove dirt.

https://github.com/jess-hammer/dual-grid-tilemap-system-unity/assets/59108399/ace1cd25-1c77-48a8-ad87-590741f7bbe7

It does NOT use `RuleTiles` directly, but does act similarly to them. It uses a custom script with hard-coded "rules" to control the placement of regular tiles.

The main reasons I love the dual-grid approach as opposed to RuleTiles is because:
- it allows the tiles to have perfectly rounded corners
- a maximum of only 16 tiles are required in the tileset, as opposed to 47 (and you could cut that number further down to just 6 if your tiles have symmetry)
- the tiles are not ambiguous for the player, in that each "dirt" or "grass" aligns with the world grid

One could also argue it's more efficient, since each tile only checks 4 neighbours as opposed to 8. But I haven't done any performance testing so no promises.

I also made a Godot version which you can check out [here](https://github.com/jess-hammer/dual-grid-tilemap-system-godot)

It is possible to get a dual-grid system working using custom RuleTiles too, however it did become quite convoluted when I tried. I made a post about it a while ago [here](https://forum.unity.com/threads/tile-transition-rule-tile-improvement-corner-based-rules.519623/#post-9057535) if you are curious though. 

### References

See Oskar Stålberg's original proposition of a dual-grid system: https://x.com/OskSta/status/1448248658865049605

Regular tile cut:

<img src="https://github.com/jess-hammer/dual-grid-tilemap-system-godot/assets/59108399/ac3c9ab6-b399-4142-8425-3de6d67249a0" width="350" title="Inward blob cut">

On-the-dual tile cut:

<img src="https://github.com/jess-hammer/dual-grid-tilemap-system-godot/assets/59108399/5399d1b6-7169-4ff8-8a17-1ba8e483fce3" width="350" title="Inward blob cut">


The dual-grid system is also mentioned in [ThinMatrix's video](https://youtu.be/buKQjkad2I0?si=9xot1uUw3PvNWvT9&t=234), 
which is what inspired me in the first place!

If you have any questions or ideas for improvements feel free to contact me at jesscodesyt@gmail.com

