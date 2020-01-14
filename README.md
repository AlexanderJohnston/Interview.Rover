# Interview.Rover

## Purpose

This program was written in 2017 to join DealerOn as part of their interview process and it serves as a high quality example of my ability to write code. I was so proud of it that I have it pinned on my GitHub profile for interviewers.

## Usage

You can run this program as `Debug`, `Release`, `Any CPU`, `x64`, and presumably `x86`.
1. First, compile the program in your desired configuration.
2. Next, navigate to the `${SolutionDir}/bin/${SelectedConfiguration}/`
3. Open Powershell or Cmd and call the program with desired arguments. [Tip: `CTRL+SHIFT+Mouse2` and click "Open Powershell window here"]

Arguments:
* If you pass no arguments, it will output help and usage guidelines.
* If the first argument contains `help` or `man` then it will display help. [Accepts `-help :help /help` etc...]
* If the first argument is a path to an existing plaintext file, then the program will attempt to load it and run. Output will be set to `${AppDomain.BaseDirectory}/output.txt`
* If the second argument is a valid path to a non-existing file then it will be created and set as the output.
* If the second argument is a valid path to an existing file then it will append the output to the end of that file.

EX: `.\Interview.Rover.exe C:\Working\input.txt C:\Working\output.txt`

## Goals and Design

The most important factor in the design is that Rover instructions are run in series. This means that there will be some total instruction set containing some amount of Rovers, but only one Rover needs to be running at a time. This permits me to create an encapsulation model where all elements are children of the Rover, which exists as an abstract entry-point for creation and destruction of all internal models. This limits the number of potential bugs which can be carried over between Rovers.

The second aspect of the design is that I didn't know what the system expected if the Rover was to move outside of its specified grid size. My model dynamically builds a new logical grid for each Rover with limits at the minimum and maximum values for an int which should safely roll over and not throw. This means that the Rover can drive into negative values without crashing. An important benefit of my grid model is that it can be easily extended into three dimensions if NASA ever invents a flying drone Rover.

Lastly, I chose to use a simple logging system of piping out the Console to a plaintext file. I would have used something fancier like Serilog, but it seemed like overkill and I know you don't want to deal with third party libraries. My console logger should pass exceptions down to your terminal or output file, so that you can easily identify where in my code there was an error. Let's hope there aren't any. :)

Unit tests were skipped because I went a little overboard with my model and ran out of time. Hopefully you will find that the quality of documentation makes up for that.

## Sample Input

Three rovers starting on a grid with 0 Maximum X and 0 Maximum Y coordinates.
The first rover starts at 2,1 facing North.
The second rover starts at 0,0 facing North.
The third rover starts at 0,0 facing South.

    0 0
    2 1 N
    LLLLLRLRLRLLRLRRRRRRMRMRMRRMRMMMM
    0 0 N
    MMMMMMMMMMMMLL
    0 0 S
    LRLRLRLRLRLRM
