namespace KapitalMedya.Application.RequestParameter
{
    /// <summary>
    ///     Pagination servisi için kullanılan entity
    /// </summary>
    public class PaginationEntity
    {
        public PaginationEntity()
        {
            PageNumber = 1;
        }

        /// <summary>
        ///     Gönderilecek maximum veri sayısı
        /// </summary>
        const int maxPageItemSize = 100;

        /// <summary>
        ///     Gönderilecek minimum veri sayısı
        /// </summary>
        private int _pageSize = 10;

        //Kullanıcıdan alınan parametre değerleri

        /// <summary>
        ///     Sayfa numarası
        /// </summary>
        public int PageNumber { get; set; }

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageItemSize) ? maxPageItemSize : value;
            }
        }
    }
}
