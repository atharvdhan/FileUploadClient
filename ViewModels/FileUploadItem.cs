using FileUploadClient.Models;
using FileUploadClient.ViewModels.Common;
using System.ComponentModel;

namespace FileUploadClient.ViewModels
{
    public class FileUploadItem : NotifyPropertyChangedBase
    {
        private readonly FileItem fileItem;

        private bool isSelected;

        private UploadStatus status;

        private long uploadedBytes;

        public FileUploadItem(FileItem fileItem)
        {
            this.fileItem = fileItem ?? throw new ArgumentNullException(nameof(fileItem));
            UploadGuid = Guid.NewGuid();
        }

        public Guid UploadGuid { get; }

        public bool IsSelected
        {
            get => isSelected;
            set => Set(ref isSelected, value);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public UploadStatus Status
        {
            get => status;
            set => Set(ref status, value);
        }

        public long UploadedBytes
        {
            get => uploadedBytes;
            set => Set(ref uploadedBytes, value);
        }

        public string Name
        {
            get => fileItem.Name;
            set
            {
                this.fileItem.Name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        public string Path
        {
            get => fileItem.Path;
            set
            {
                this.fileItem.Path = value;
                RaisePropertyChanged(nameof(Path));
            }
        }

        public long Size
        {
            get => fileItem.Size;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Size cannot be negative.");
                }

                if (value == Size) return;

                this.fileItem.Size = value;
                RaisePropertyChanged(nameof(Size));
            }
        }
    }

    public enum UploadStatus
    {
        Queued,
        Uploading,
        Paused,
        Completed,
        Failed,
        Canceled
    }
}
