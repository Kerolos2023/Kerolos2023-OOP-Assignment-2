namespace PatternsLab.Problems.Builder;

public class CourseRegistration
{
    public string StudentName { get; }
    public string CourseName { get; }
    public string RegistrationType { get; }
    public string? GroupCode { get; }

    private CourseRegistration(
        string studentName,
        string courseName,
        string registrationType,
        string? groupCode)
    {
        StudentName = studentName;
        CourseName = courseName;
        RegistrationType = registrationType;
        GroupCode = groupCode;
    }

    public class Builder
    {
        private string? _studentName;
        private string? _courseName;
        private string? _registrationType;
        private string? _groupCode;

        public Builder ForStudent(string studentName)
        {
            _studentName = studentName;
            return this;
        }

        public Builder ForCourse(string courseName)
        {
            _courseName = courseName;
            return this;
        }

        public Builder AsLiveGroup(string groupCode)
        {
            _registrationType = "LiveGroup";
            _groupCode = groupCode;

            return this;
        }

        public Builder AsVideosOnly()
        {
            _registrationType = "VideosOnly";
            _groupCode = null;

            return this;
        }

        public Builder WithGroupCode(string groupCode)
        {
            _groupCode = groupCode;
            return this;
        }

        public CourseRegistration Build()
        {
            if (string.IsNullOrWhiteSpace(_studentName))
                throw new InvalidOperationException(
                    "Student name is required.");

            if (string.IsNullOrWhiteSpace(_courseName))
                throw new InvalidOperationException(
                    "Course name is required.");

            if (_registrationType == "LiveGroup" &&
                string.IsNullOrWhiteSpace(_groupCode))
            {
                throw new InvalidOperationException(
                    "LiveGroup registration requires a GroupCode.");
            }

            if (_registrationType == "VideosOnly" &&
                !string.IsNullOrWhiteSpace(_groupCode))
            {
                throw new InvalidOperationException(
                    "VideosOnly registration must not have a GroupCode.");
            }

            if (string.IsNullOrWhiteSpace(_registrationType))
                throw new InvalidOperationException(
                    "Registration type is required.");

            return new CourseRegistration(
                _studentName,
                _courseName,
                _registrationType,
                _groupCode);
        }
    }
}