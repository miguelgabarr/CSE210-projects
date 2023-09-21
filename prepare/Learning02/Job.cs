using System;

public class Job
{
    private string _company;
    private string _jobTitle;
    private int _startYear;
    private int _endYear;

    // Constructor to initialize the job details
    public Job (string company, string jobTitle, int _startYear, int _endYear)

    {
        _company = company;
        _jobTitle = jobTitle;
        _startYear = startYear;
        _endYear = _endYear;
    }

    // Method to display the job information
    public void DisplayJob()

    {
        return $"{_jobTitle} ({_company}) {_startYear}-{_endYear}";
    }

    //Properties to acces job details
    public string Company
    {
        get { return _company; }
        set { _company = value; }
    }

    public string JobTitle
    {
        get { return _jobTitle; }
        set {_jobTitle = value; }
    }
    
       public int StartYear
    {
        get { return _startYear; }
        set {_startYear = value; }
    }
         public int EndYear
    {
        get { return _endYear; }
        set {_endYear = value; }
    }
}