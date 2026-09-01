#include "export.h"
#include "pcl/pcl_base.h"
#include "pcl/point_types.h"
#include <pcl/filters/extract_indices.h>

using namespace pcl;
using namespace std;

using point_t = PointXYZI;
using pointcloud_t = PointCloud<point_t>;
using extractindices_t = ExtractIndices<point_t>;

EXPORT(extractindices_t*) extractindices_pointxyzi_ctor()
{
    return new extractindices_t();
}

EXPORT(void) extractindices_pointxyzi_delete(extractindices_t** ptr)
{
    delete* ptr;
    *ptr = NULL;
}

EXPORT(void) extractindices_pointxyzi_set_input_cloud(extractindices_t* ptr, pointcloud_t* cloud)
{
    pointcloud_t::Ptr shared(std::make_shared<pointcloud_t>(*cloud));
    ptr->setInputCloud(shared);
}

EXPORT(const pointcloud_t*) extractindices_pointxyzi_get_input_cloud(extractindices_t* ptr)
{
    return ptr->getInputCloud().get();
}

EXPORT(void) extractindices_pointxyzi_filter_directly(extractindices_t* ptr, pointcloud_t* output)
{
    pointcloud_t::Ptr shared(std::make_shared<pointcloud_t>(*output));
    ptr->filterDirectly(shared);
    *output = *shared;
}

EXPORT(void) extractindices_pointxyzi_filter(extractindices_t* ptr, pointcloud_t* output)
{
    ptr->filter(*output);
}

EXPORT(void) extractindices_pointxyzi_set_filter_indices(extractindices_t* ptr, std::size_t row_start, std::size_t col_start, std::size_t nb_rows, std::size_t nb_cols)
{
    ptr->setIndices(row_start, col_start, nb_rows, nb_cols);
}

EXPORT(void) extractindices_pointxyzi_set_filter_indices_vector(extractindices_t* ptr, std::vector<int>* indices)
{
    pcl::PointIndices::Ptr indices_ptr(new pcl::PointIndices());
    indices_ptr->indices = *indices;
    ptr->setIndices(indices_ptr);
}

EXPORT(void) extractindices_pointxyzi_get_filter_indices_vector(extractindices_t* ptr, std::vector<int>* indices)
{
    pcl::IndicesPtr indices_ptr = ptr->getIndices();
    indices->assign(indices_ptr->begin(), indices_ptr->end());
}

EXPORT(void) extractindices_pointxyzi_set_keep_organized(extractindices_t* ptr, int keep_organized)
{
    ptr->setKeepOrganized((bool)keep_organized);
}

EXPORT(int) extractindices_pointxyzi_get_keep_organized(extractindices_t* ptr)
{
    return ptr->getKeepOrganized();
}

EXPORT(void) extractindices_pointxyzi_set_negative(extractindices_t* ptr, int negative)
{
    ptr->setNegative((bool)negative);
}

EXPORT(int) extractindices_pointxyzi_get_negative(extractindices_t* ptr)
{
    return ptr->getNegative();
}