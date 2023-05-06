public class Resume
{
    private string _personName;
    private List<Job> _jobHistory;

    public Resume(string personName)
    {
        _personName = personName;
        _jobHistory = new List<Job>();
    }

    public void AddJob(Job job)
    {
        _jobHistory.Add(job);
    }

    public void Display()
    {
        Console.WriteLine("Resume for {0}:", _personName);
        foreach (Job job in _jobHistory)
        {
            job.Display();
        }
    }
}