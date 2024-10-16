// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using SerializationJourney.Benchmarks;


// BenchmarkRunner.Run<BenchSerialize>();
// BenchmarkRunner.Run<BenchDeserialize>();
BenchmarkRunner.Run<BenchBig>();
