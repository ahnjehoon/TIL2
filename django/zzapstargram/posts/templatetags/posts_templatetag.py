from django import template

register = template.Library()

@register.filter
def hashtag_link(post):
	content = post.content
	hashtags = post.hash_tags.all()
	for hashtag in hashtags:
		content = content.replace(
			f'{hashtag.content}'
			, f'<a href="/hashtags/{hashtag.id}/">{hashtag.content}</a>'
		)
	return content