namespace Pcl.NET
{
    public class ExtractIndicesPointXYZRGBA : ExtractIndices<PointXYZRGBA>
    {
        private readonly VectorInt _indices;
        private PointCloud<PointXYZRGBA>? _input = null;

        public ExtractIndicesPointXYZRGBA()
        {
            _indices = new VectorInt();
            _ptr = Invoke.extractindices_pointxyzrgba_ctor();
        }

        public override bool KeepOrganized
        {
            get
            {
                ThrowIfDisposed();
                int val = Invoke.extractindices_pointxyzrgba_get_keep_organized(_ptr);
                return val != 0;
            }
            set
            {
                ThrowIfDisposed();
                int val = value ? 1 : 0;
                Invoke.extractindices_pointxyzrgba_set_keep_organized(_ptr, val);
            }
        }

        public override bool IsNegative
        {
            get
            {
                ThrowIfDisposed();
                int val = Invoke.extractindices_pointxyzrgba_get_negative(_ptr);
                return val != 0;
            }
            set
            {
                ThrowIfDisposed();
                int val = value ? 1 : 0;
                Invoke.extractindices_pointxyzrgba_set_negative(_ptr, val);
            }
        }

        public override PointCloud<PointXYZRGBA>? Input
        {
            get
            {
                ThrowIfDisposed();
                return _input;
            }
            set
            {
                ThrowIfDisposed();
                ArgumentNullException.ThrowIfNull(value, nameof(value));
                Invoke.extractindices_pointxyzrgba_set_input_cloud(_ptr, value!);
                _input = value;
            }
        }

        public override PointCloud<PointXYZRGBA> ApplyFilter()
        {
            ThrowIfDisposed();
            ThrowIfInputNotSet();
            PointCloudXYZRGBA output = new PointCloudXYZRGBA();
            Invoke.extractindices_pointxyzrgba_filter(_ptr, output);
            return output;
        }

        public override void SetIndices(long row_start, long col_start, long nb_rows, long nb_cols)
        {
            ThrowIfDisposed();
            ThrowIfBadIndices(row_start, col_start, nb_rows, nb_cols);
            Invoke.cropbox_pointxyzrgba_set_filter_indices(_ptr, (ulong)row_start, (ulong)col_start, (ulong)nb_rows, (ulong)nb_cols);
        }

        public override VectorInt Indices
        {
            get
            {
                ThrowIfDisposed();
                Invoke.extractindices_pointxyzrgba_get_filter_indices_vector(_ptr, _indices);
                return _indices;
            }

            set
            {
                ThrowIfDisposed();
                Invoke.extractindices_pointxyzrgba_set_filter_indices_vector(_ptr, value);
            }
        }

        #region Dispose

        protected override void DisposeObject()
        {
            if (!_suppressDispose)
            {
                Invoke.extractindices_pointxyzrgba_delete(ref _ptr);
            }
        }

        #endregion
    }
}
