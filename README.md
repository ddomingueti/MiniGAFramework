# MiniGAFramework
A very small and simple Genetic Algorithm framework for your needs!

While in my graduation course in 2018, I took part in a subject called Bionspired Algorithm. On that occasion, each student developed solutions for a few classical problems using a bioinspired algorithm. Since the first part of the subject consisted on to implement all the solutions using a Genetic Algorithm, I developed this framework to learn and also to minimize the time I'd take to develop the basic algorithm again for each problem.

Nowadays, lots of tools and libraries exist to handle AI problems. Still, I decided to upload this on Github as a showcase and also to help other developers gain some time in their development whether your choice is for a small and concise library. Some fixes were made recently in order to transform in a real use framework, and all the tasks for that first part are now listed as examples. The example projects are:
<ul>
  <li>Finding the root of a real number;</li>
  <li>A solution for the Knaspsack Problem; and</li>
  <li>A solution for the Travelling Salesman Problem.</li>
</ul>

<h2>How to use</h2>
The MiniGAFramework contains one basic class for the Genetic Algorithm, a basic class describing an Individual of the current population, and a static class with two classical methods for parents selection (roulete wheel and tournament methods). Simple extend the two classes (GeneticAlgorithm and Individual) to match your needs, and create a Main to run your problem instance. You can extend nearly all the methods to fulfills your needs. If you're in doubt, take a look at the examples for a guidance.

<h2>About the tools used</h2>
This project was deveoped in C# language, using the Asp Net Core 2.0 library.
