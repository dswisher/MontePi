# Monte Carlo Estimation of PI, Animated

A simple animation of estimating PI, using a [Monte Carlo](https://en.wikipedia.org/wiki/Monte_Carlo_method) simulation, built in Unity.

Balls at thrown at a unit square target, which contains a unit circle.
The ratio of balls inside the circle to those thrown is an estimate of PI.

# Design

Balls spawn behind the camera at a fixed rate, and fly to their pre-chosen spot on the target.
When they strike the target, they are recorded as a hit or miss, and the value of PI is updated.

