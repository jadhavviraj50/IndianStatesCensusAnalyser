using NUnit.Framework;
using IndianStatesCensusAnalyser;
using IndianStatesCensusAnalyser.POCO;
using Newtonsoft.Json;
using System.Collections.Generic;
using static IndianStatesCensusAnalyser.CensusAnalyser;



namespace CensusAnalyserTest
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"C:\Users\HP\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFilePath = @"C:\Users\HP\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\WrongIndiaStateCensusData.csv";
        static string delimiterIndianCensusFilePath = @"C:\Users\HP\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\DelimiterIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"C:\Users\HP\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaData.csv";
        static string wrongIndianStateCensusFileType = @"C:\Users\HP\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCensusData.txt";
        static string indianStateCodeFilePath = @"C:\Users\HP\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCode.csv";
        static string wrongIndianStateCodeFilePath = @"C:\Users\HP\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCode.txt";
        static string delimiterIndianStateCodeFilePath = @"C:\Users\HP\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\DelimiterIndiaStateCode.csv";
        static string wrongHeaderStateCodeFilePath = @"C:\Users\HP\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\WrongIndiaStateCode.csv";

        IndianStatesCensusAnalyser.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndianStatesCensusAnalyser.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(36, stateRecord.Count);
        }

        [Test]

        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.etype);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.etype);
        }

        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFileType, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.etype);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.etype);
        }



    }
}