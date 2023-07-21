using Service.Core.Application.Dto;
using Service.Core.Application.Dto.Service.Core.Model.Entities;
using Service.Core.Model.Entities;


namespace Service.Core.Application.Helper
{
    public static class Extention
    {
        public static BookInfoDto ToDto(this BookInfoEntity bookInfoEntity)
        {
            return new BookInfoDto()
            {
                encrypted = bookInfoEntity.encrypted,
                id = bookInfoEntity.id,
                isRtl = bookInfoEntity.isRtl,
                type = bookInfoEntity.type,
                title = bookInfoEntity.title,
                refId   = bookInfoEntity.refId,
                rates = bookInfoEntity.rates.Select(e => new RateDto
                {
                    count = e.count,
                    value = e.value,
                }).ToList(),
                files = bookInfoEntity.files.Select(e => new FileDto
                {
                    duration = e.duration,
                    bookId = e.bookId,
                    id = e.id,
                    sequenceNo = e.sequenceNo,
                    size = e.size,
                    title = e.title,
                    type = e.type,
                }).ToList(),
                labels = bookInfoEntity.labels,
                numberOfPages = bookInfoEntity.numberOfPages,
                offText = bookInfoEntity.offText,
                physicalBeforeOffPrice = bookInfoEntity.physicalBeforeOffPrice,
                PhysicalPrice = bookInfoEntity.PhysicalPrice,
                price = bookInfoEntity.price,
                priceColor = bookInfoEntity.priceColor,
                publisher = bookInfoEntity.publisher,
                faqs = bookInfoEntity.faqs,
                hasPhysicalEdition = bookInfoEntity.hasPhysicalEdition,
                currencyBeforeOffPrice = bookInfoEntity.currencyBeforeOffPrice,
                shareUri = bookInfoEntity.shareUri,
                showOverlay = bookInfoEntity.showOverlay,
                shareText = bookInfoEntity.shareText,
                sourceBookId = bookInfoEntity.sourceBookId,
                state = bookInfoEntity.state,
                sticker = bookInfoEntity.sticker,
                publisherSlug = bookInfoEntity.publisherSlug,
                subscriptionAvailable = bookInfoEntity.subscriptionAvailable,
                beforeOffPrice = bookInfoEntity.beforeOffPrice,
                canonicalId = bookInfoEntity.canonicalId,
                coverUri = bookInfoEntity.coverUri,
                currencyPrice = bookInfoEntity.currencyPrice,
                destination = bookInfoEntity.destination,
                htmlDescription = bookInfoEntity.htmlDescription,
                description = bookInfoEntity.description,
                jsonDescription = bookInfoEntity.jsonDescription,
                PublisherID = bookInfoEntity.PublisherID,
                rating = bookInfoEntity.rating,
                rateDetails = bookInfoEntity.rateDetails.Select(e => new RateDetailDto()
                {
                    id = e.id,
                    point = e.point,
                    title = e.title,
                }).ToList(),
                categories = bookInfoEntity.categories.Select(e => new CategoryDto()
                {
                    icon = e.icon,
                    slug = e.slug,
                    id = e.id,
                    parent = e.parent,
                    title = e.title,
                }).ToList(),

                authors = bookInfoEntity.authors.Select(e => new AuthorDto() 
                {
                    id = e.id,
                    firstName = e.firstName,
                    slug = e.slug,
                    lastName = e.lastName,
                    type = e.type,
                }).ToList(),

                
            };
        }
    }
}
