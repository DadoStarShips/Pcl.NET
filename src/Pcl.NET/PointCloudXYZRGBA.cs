﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Pcl.NET
{

    public class PointCloudXYZRGBA : PointCloud<PointXYZRGBA>
    {
        private readonly VectorXYZRGBA _points;

        public override int Width 
        { 
            get
            {
                ThrowIfDisposed();
                return (int)Invoke.pointcloud_xyzrgba_get_width(_ptr);
            }
            set 
            {
                ThrowIfDisposed();
                Invoke.pointcloud_xyzrgba_set_width(_ptr, (uint)value);
            }
        }
        public override int Height
        {
            get
            {
                ThrowIfDisposed();
                return (int)Invoke.pointcloud_xyzrgba_get_height(_ptr);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.pointcloud_xyzrgba_set_height(_ptr, (uint)value);
            }
        }
        public override bool IsDense
        {
            get
            {
                ThrowIfDisposed();
                return Invoke.pointcloud_xyzrgba_get_is_dense(_ptr);
            }
            set
            {
                ThrowIfDisposed();
                Invoke.pointcloud_xyzrgba_set_is_dense(_ptr, value);
            }
        }
        public override Vector<PointXYZRGBA> Points => _points;
        public override long Count
        {
            get
            {
                ThrowIfDisposed();
                return (long)Invoke.pointcloud_xyzrgba_size(_ptr);
            }
        }
        public override bool IsOrganized
        {
            get
            {
                ThrowIfDisposed();
                return Invoke.pointcloud_xyzrgba_is_organized(_ptr);
            }
        }

        private PointCloudXYZRGBA(IntPtr ptr)
        {
            _ptr = ptr;
            _points = new VectorXYZRGBA(Invoke.pointcloud_xyzrgba_points(_ptr));
        }

        internal PointCloudXYZRGBA(IntPtr ptr, bool suppressDispose)
          : this(ptr)
        {
            _suppressDispose = suppressDispose;
        }

        public PointCloudXYZRGBA()
          : this(Invoke.pointcloud_xyz_ctor())
        {
        }

        public PointCloudXYZRGBA(int width, int height)
          : this(Invoke.pointcloud_xyz_ctor_wh((uint)width, (uint)height))
        {
        }

        public unsafe override void Add(PointXYZRGBA value)
        {
            ThrowIfDisposed();
            Invoke.pointcloud_xyzrgba_add(_ptr, &value);
        }

        public unsafe override ref PointXYZRGBA At(int col, int row)
        {
            ThrowIfDisposed();
            return ref System.Runtime.CompilerServices.Unsafe.AsRef<PointXYZRGBA>(Invoke.pointcloud_xyzi_at_colrow(_ptr, col, row));
        }

        public PointCloudXYZRGBA Downsample(int factor)
        {
            PointCloudXYZRGBA output = new PointCloudXYZRGBA(this.Width, this.Height);
            ThrowIfDisposed();
            Invoke.pointcloud_xyzrgba_downsample(_ptr, factor, output);
            return output;
        }

        public static PointCloudXYZRGBA operator +(PointCloudXYZRGBA a, PointCloudXYZRGBA b)
        {
            return Concatenate(a, b);
        }

        #region Static

        public static PointCloudXYZRGBA Concatenate(PointCloudXYZRGBA a, PointCloudXYZRGBA b)
        {
            PointCloudXYZRGBA outpc = new PointCloudXYZRGBA();

            Invoke.pointcloud_xyz_concatenate(a, b, outpc);

            return outpc;
        }

        #endregion

        #region Dispose
        protected override void DisposeObject()
        {
            if (!_suppressDispose)
            {
                Invoke.pointcloud_xyzrgba_delete(ref _ptr);
            }
        } 
        #endregion
    }
}
