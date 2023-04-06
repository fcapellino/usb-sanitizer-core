namespace USB_Sanitizer
{
    class RemovableDrive
    {
        public string RootDirectory { get; set; }
        public string VolumeLabel { get; set; }

        public override string ToString()
        {
            return $"{RootDirectory} - {VolumeLabel.ToUpper()}";
        }
    }
}
